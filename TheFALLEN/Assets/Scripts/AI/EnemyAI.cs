using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : EnemyBaseClass
{
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 2f;
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
        transform.position += direction * speed * Time.deltaTime;  // Using inherited speed
    }

    private void AttackPlayer()
    {
        // Logic for attacking the player
        Debug.Log("Attacking player!");
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    protected override void Die()
    {
        base.Die();
    }
}
