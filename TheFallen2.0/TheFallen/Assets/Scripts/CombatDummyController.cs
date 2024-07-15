using System.Collections;
using System.Collections.Generic;
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

    private PlayerController pc;
    private GameObject aliveGO, deadGO;
    private Rigidbody2D rbAlive, rbDead;
    private Animator aliveAnim;

    private void Start()
    {
        currentHealth = maxHealth;

        //pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

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
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Damage(float amount)
    {
        currentHealth -= amount;

        Instantiate(hitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        aliveAnim.SetTrigger("damage");

        if (applyKnockBack && currentHealth > 0.0f)
        {
            KnockBack(); 
        }

        if (currentHealth < 0.0f)
        {
            Die();
        }
    }

    private void KnockBack()
    {
        knockBack = true;
        knockBackStart = Time.time;
        rbAlive.velocity = new Vector2 (knockBackSpeedX, knockBackSpeedY);
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
