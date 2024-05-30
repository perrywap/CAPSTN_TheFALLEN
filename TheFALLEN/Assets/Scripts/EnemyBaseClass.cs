using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
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
=======
public class EnemyBaseClass : MonoBehaviour
{
    [SerializeField] protected float HP = 10;
    [SerializeField] private float attack;
    [SerializeField] private float defense;
    [SerializeField] private float attackSpeed;
    [SerializeField] protected float speed;  // Made protected to be accessible by derived classes

    public float Attack => attack;
    public float Defense => defense;
    public float AttackSpeed => attackSpeed;

    public virtual void TakeDamage(float damage)
    {
        HP -= damage;
        Debug.Log("Damage has been taken.");
>>>>>>> Stashed changes
        if (HP <= 0)
        {
            Die();
        }
    }

<<<<<<< Updated upstream
    private void Die()
    {
        // Logic for enemy death
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
=======
    protected virtual void Die()
    {
        Debug.Log("Enemy dead");
        Destroy(gameObject);
    }

   
    protected virtual void Update()
    {
        // Base update logic
    }
>>>>>>> Stashed changes
}
