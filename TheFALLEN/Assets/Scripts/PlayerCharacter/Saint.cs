using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saint : UnitBase
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

    [Header("Revive Skill")]
    [SerializeField] private float reviveCooldownTime;
    [SerializeField] private float reviveNextTime;

    // Update is called once per frame
    void Update()
    {
        // Handle cooldowns or other update-related tasks specific to Saint
    }

    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        if (Time.time - supportSkillNextTime < supportSkillCooldownTime)
        {
            return;
        }
        supportSkillNextTime = Time.time;

        // Implement support skill logic here
        Debug.Log("Saint is using SUPPORT skill");
    }

    public void ActivateBarrierSkill()
    {
        if (Time.time - barrierNextTime < barrierCooldownTime)
        {
            return;
        }
        barrierNextTime = Time.time;

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

        HealAllAllies(healAmount);

        Debug.Log("Saint is using HEAL skill");
    }

    public void ActivateReviveSkill()
    {
        if (Time.time - reviveNextTime < reviveCooldownTime)
        {
            return;
        }
        reviveNextTime = Time.time;

        ReviveFallenAlly();

        Debug.Log("Saint is using REVIVE skill");
    }
    #endregion

    private void HealAllAllies(float amount)
    {
        // Implement the logic to heal all allies
    }

    private void ReviveFallenAlly()
    {
        // Implement the logic to revive a fallen ally
    }
}
