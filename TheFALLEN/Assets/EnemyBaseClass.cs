using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void TakeDamage(float damage) override
    {
        HP -= damage;
        Debug.Log("Damage has been taken.");
        if (HP <= 0)
        {
            Die();
        }
    }

      public void Die() override
    {
        Debug.Log("Enemy dead");
        Destroy(gameObject);
    }

   
    private void Update()
    {
        // Base update logic
    }
}
