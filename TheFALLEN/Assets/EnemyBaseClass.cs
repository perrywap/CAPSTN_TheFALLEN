using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{
    [SerializeField] protected float HP = 10f;
    [SerializeField] private float attack;
    [SerializeField] private float defense;
    [SerializeField] private float attackSpeed;
    [SerializeField] public float speed = 4f ;  // Made protected to be accessible by derived classes

    public float Attack => attack;
    public float Defense => defense;
    public float AttackSpeed => attackSpeed;

    // Declared as virtual to allow overriding in derived classes
    public virtual void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            HP -= damage;
            Debug.Log("Damage has been taken.");
            if (HP <= 0)
            {
                Die();
            }
        }
    }

    // Declared as virtual to allow overriding in derived classes
    public virtual void Die()
    {
        Debug.Log("Enemy dead");
        Destroy(gameObject);
    }

    // Mark the Update method as virtual
    protected virtual void Update()
    {
        // Base update logic
    }
}
