using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class CombatDummyController : MonoBehaviour
{
    [SerializeField] private GameObject hitParticle;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    [SerializeField] private float knockBackSpeedX, knockBackSpeedY, knockBackDuration, knockBackDeathSpeedX, knockBackDeathSpeedY;
    [SerializeField] private bool applyKnockBack;
    private bool knockBack;
    private float knockBackStart;

    private GameObject player;
    private GameObject aliveGO, deadGO;
    public Rigidbody2D rbAlive, rbDead;
    private Animator aliveAnim;

    public bool playerIsOnLeft;
    private Vector3 playerDirection;

    private void Start()
    {
        currentHealth = maxHealth;

        aliveGO = transform.Find("Alive").gameObject;
        deadGO = transform.Find("Dead").gameObject;

        aliveAnim = aliveGO.GetComponent<Animator>();

        rbAlive = aliveGO.GetComponent <Rigidbody2D>();
        rbDead = deadGO.GetComponent<Rigidbody2D>();

        aliveGO.SetActive(true);
        deadGO.SetActive(false);
    }

    private void Update()
    {
        CheckKnockBack();
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerDirection = player.transform.position - rbAlive.transform.position;
        playerIsOnLeft = playerDirection.x < rbAlive.transform.position.x ? true : false;
    }

    private void Damage(float amount)
    {
        currentHealth -= amount;

        Instantiate(hitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        aliveAnim.SetTrigger("damage");

        if (applyKnockBack && currentHealth > 0.0f)
        {
            float[] speed = { knockBackDeathSpeedX, knockBackDeathSpeedY };
            KnockBack(speed);
        }

        if (currentHealth < 0.0f)
        {
            Die();
        }
    }

    public void KnockBack(float[] speed)
    {
        knockBack = true;
        knockBackStart = Time.time;

        if (playerIsOnLeft)
            rbAlive.velocity = new Vector2(speed[0], speed[1]);
        else if(!playerIsOnLeft)
            rbAlive.velocity = new Vector2(-speed[0], speed[1]);
    }

    private void CheckKnockBack()
    {
        if(Time.time >= knockBackStart + knockBackDuration && knockBack)
        {
            knockBack = false;
            rbAlive.velocity = new Vector2(0.0f, rbAlive.velocity.y); 
        }
    }    

    private void Die()
    {
        aliveGO.SetActive (false);
        deadGO.SetActive (true);

        deadGO.transform.position = aliveGO.transform.position;

        rbDead.velocity = new Vector2 (knockBackDeathSpeedX, knockBackDeathSpeedY);

    }
}
