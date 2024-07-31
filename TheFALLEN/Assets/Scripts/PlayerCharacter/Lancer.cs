using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lancer : Player
{
    [Header("Support Skill")]
    [SerializeField] private float SupportSkillCoolDownTime;
    [SerializeField] private float SupportSkillNextTime;

    [Header("Light Skill")]
    [SerializeField] private float LightSkillCoolDownTime;
    [SerializeField] private float LightSkillNextTime;

    [Header("Heavy Skill")]
    [SerializeField] private float HeavySkillCoolDownTime;
    [SerializeField] private float HeavySkillNextTime;

    [Header("Ultimate Skill")]
    [SerializeField] private float UltimateSkillCoolDownTime;
    [SerializeField] private float UltimateSkillNextTime;

    [SerializeField] bool isAttacking = false;

    //enemy detection
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask wallLayer; //change to platform layer if thats what we are using

    //highjump variables
    [SerializeField] private GameObject JumpDamage; //instantiate a AOE under the player using this
    [SerializeField] private Transform JumpDamageSpawn; //link the uh player is touching ground rigid body/collider to this as it serves same purpose to where it will spawn out from on impact

    //lance thrust variables
    [SerializeField] private float thrustRange;

    //ravaging spear variables
    [SerializeField] private float duration; //duration of attack
    [SerializeField] private float interval; //time between hits
    [SerializeField] private int damagePerStrike;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackTimer = 0f;

    //manaspear variables
    [SerializeField] private GameObject spear; //has script spear
    [SerializeField] private Transform spearSpawn;
    [SerializeField] private float throwSpeed;
    [SerializeField] private int damageUlt;
    [SerializeField] private float explosionRad;
    [SerializeField] private Rigidbody2D rbSpear;
    
    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        if (Time.time - SupportSkillNextTime < SupportSkillCoolDownTime)
        {
            return;
        }
        SupportSkillNextTime = Time.time;
        //call jump function here or something similar? I'm having a hard time seeing where the sustained jump is effected but it is called here and change the jumpforce here nalang
        //animate the jump here
        //on landing call this instantiate jump damage
        Instantiate(JumpDamage, JumpDamageSpawn);
        //call damage script here to check overlap of jump damage collider with enemy
        StartCoroutine(waitingSkill(0.5f));
        Destroy(JumpDamage);
        Debug.Log("Lancer is using HIGH JUMP skill");
    }

    public override void ActivateLightSkill()
    {
        if (Time.time - LightSkillNextTime < LightSkillCoolDownTime)
        {
            return;
        }
        LightSkillNextTime = Time.time;

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
            //closestEnemy.GetComponent<Enemy>().TakeDamage(10); //swap with take damage script ng enemy on this
        }

        Debug.Log("Lancer is using THRUST skill");
    }

    public override void ActivateHeavySkill()
    {
        if (Time.time - HeavySkillNextTime < HeavySkillCoolDownTime)
        {
            return;
        }
        HeavySkillNextTime = Time.time;

        while (attackTimer < duration)
        {
            // Perform attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
                //enemy.GetComponent<Enemy>().TakeDamage(damagePerStrike);
            }

            attackTimer += interval;
            StartCoroutine(waitingSkill(interval));
        }

        isAttacking = false;

        Debug.Log("Lancer is using MUTILATE skill");
    }

    public override void ActivateUltimateSkill()
    {
        if (Time.time - UltimateSkillNextTime < UltimateSkillCoolDownTime)
        {
            return;
        }
        UltimateSkillNextTime = Time.time;

        Instantiate(spear, spearSpawn); //this is the spear script

        

        Debug.Log("Lancer is using MANA SPEAR skill");
    }

    IEnumerator waitingSkill(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    #endregion
}
