using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : UnitBaseClass
{
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float moveSpeed = 2f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

     protected override void Update()
    {
        base.Update(); 

        if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            MoveTowardsPlayer();
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void AttackPlayer()
    {
        // Logic for attacking the player
        Debug.Log("Attacking player!");
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Logic for enemy death
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
