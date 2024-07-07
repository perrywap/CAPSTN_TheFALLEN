using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saint : Player
{
    [Header("Support Skill")]
    [SerializeField] private float supportSkillCooldownTime;
    [SerializeField] private float supportSkillNextTime;

    [Header("Barrier Skill")]
    [SerializeField] private float barrierCooldownTime;
    [SerializeField] private float barrierNextTime;
    [SerializeField] private GameObject barrierPrefab;
    [SerializeField] private Transform barrierSpawn;

    [Header("Heal Skill")]
    [SerializeField] private float healCooldownTime;
    [SerializeField] private float healNextTime;
    [SerializeField] private float healAmount;

    [Header("Debuff Skill")]
    [SerializeField] private float debuffCooldownTime;
    [SerializeField] private float debuffNextTime;
    [SerializeField] private float debuffDuration;

    [Header("Revive Skill")]
    [SerializeField] private float reviveCooldownTime;
    [SerializeField] private float reviveNextTime;

    private void Update()
    {
        // Call the skill activation methods based on player input or other conditions
    }

    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        // Example of activating a support skill
    }

    public void ActivateBarrierSkill()
    {
        if (Time.time - barrierNextTime < barrierCooldownTime)
        {
            return;
        }
        barrierNextTime = Time.time;

        // Cast the barrier at the specified position
        Instantiate(barrierPrefab, barrierSpawn.position, barrierSpawn.rotation);

        Debug.Log("Saint is using BARRIER skill");
    }

    public void ActivateHealSkill()
    {
        if (Time.time - healNextTime < healCooldownTime)
        {
            return;
        }
        healNextTime = Time.time;

        // Heal all allies
        HealAllAllies(healAmount);

        Debug.Log("Saint is using HEAL skill");
    }

    public void ActivateDebuffSkill()
    {
        if (Time.time - debuffNextTime < debuffCooldownTime)
        {
            return;
        }
        debuffNextTime = Time.time;

        // Apply debuff to enemies
        ApplyDebuffToEnemies(debuffDuration);

        Debug.Log("Saint is using DEBUFF skill");
    }

    public void ActivateReviveSkill()
    {
        if (Time.time - reviveNextTime < reviveCooldownTime)
        {
            return;
        }
        reviveNextTime = Time.time;

        // Revive a fallen ally
        ReviveFallenAlly();

        Debug.Log("Saint is using REVIVE skill");
    }
    #endregion

    private void HealAllAllies(float amount)
    {
        // Implement the logic to heal all allies
    }

    private void ApplyDebuffToEnemies(float duration)
    {
        // Implement the logic to apply debuff to enemies
    }

    private void ReviveFallenAlly()
    {
        // Implement the logic to revive a fallen ally
    }
}
