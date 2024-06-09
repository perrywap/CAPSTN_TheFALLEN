using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lancer : MonoBehaviour
{
    [SerializeField] private float cooldownTime;
    [SerializeField] private float nextTime; //to separate different cooldowns between different skills just make a different nextTime variable for that specific skill
    [SerializeField] private float thrustRange;
    public LayerMask enemyLayer;
    public GameObject JumpDamage;
    public Transform JumpDamageSpawn;

    
    public void StartCooldown() => nextTime = Time.time + cooldownTime;
    public void ActivateSupportSkill()
    {
       if(Time.time-nextTime < cooldownTime)
        {
            return;
        }
       nextTime = Time.time;

            //animate player jumping here
            Instantiate(JumpDamage, JumpDamageSpawn); //JumpDamageSpawn can be changed to the player transform para mag spawn yung AOE around player
            Destroy(JumpDamage);
            Debug.Log("Lancer is using HIGH JUMP skill");
        
    }

    public void ActivateLightSkill()
    {
        if (Time.time - nextTime < cooldownTime)
        {
            return;
        }
        nextTime = Time.time;

        //animate the lance thrust here

        Collider2D closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        Vector2 thrustPosition = transform.position + transform.right * thrustRange;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(thrustPosition, thrustRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            // Pull the enemy closer to the player
            Vector2 pullDirection = (transform.position - closestEnemy.transform.position).normalized;
            float pullStrength = 5f;
            closestEnemy.GetComponent<Rigidbody2D>().AddForce(pullDirection * pullStrength, ForceMode2D.Impulse);

            // Deal damage to the enemy
            Debug.Log("Hit enemy: " + closestEnemy.name);
            closestEnemy.GetComponent<Enemy>().TakeDamage(10); //swap with take damage script ng enemy on this
        }

        Debug.Log("Lancer is using THRUST skill");
    }

    public void ActivateHeavySkill()
    {
        if (Time.time - nextTime < cooldownTime)
        {
            return;
        }
        nextTime = Time.time;

        Debug.Log("Lancer is using RAVAGING SPEAR skill");
    }

    public void ActivateUltimateSkill()
    {
        if (Time.time - nextTime < cooldownTime)
        {
            return;
        }
        nextTime = Time.time;

        Debug.Log("Lancer is using MANA SPEAR skill");
    }
}
