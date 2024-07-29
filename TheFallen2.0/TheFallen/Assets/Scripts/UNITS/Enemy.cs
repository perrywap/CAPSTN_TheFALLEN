using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
    public Rigidbody2D rb;
    private Animator aliveAnim;

    public bool playerIsOnLeft;

    private void Start()
    {
        currentHealth = maxHealth;

        aliveAnim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckKnockBack();
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerIsOnLeft = player.transform.position.x < this.transform.position.x ? true : false;
    }

    private void Damage(float amount)
    {
        currentHealth -= amount;

        Instantiate(hitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        aliveAnim.SetTrigger("damage");

        if (applyKnockBack && currentHealth > 0.0f)
        {
            //float[] speed = { knockBackDeathSpeedX, knockBackDeathSpeedY };
            //KnockBack(speed);
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
            rb.velocity = new Vector2(speed[0], speed[1]);
        else if (!playerIsOnLeft)
            rb.velocity = new Vector2(-speed[0], speed[1]);
    }

    private void CheckKnockBack()
    {
        if (Time.time >= knockBackStart + knockBackDuration && knockBack)
        {
            knockBack = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
