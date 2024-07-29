using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saint : BaseUnit
{
    [Header("Barrier Skill")]
    [SerializeField] private float barrierCooldownTime;
    [SerializeField] private GameObject barrierPrefab;
    [SerializeField] private Transform barrierSpawn;

    [Header("Heal Skill")]
    [SerializeField] private float healCooldownTime;
    [SerializeField] private float healAmount;

    [Header("Revive Skill")]
    [SerializeField] private float reviveCooldownTime;

    private float barrierNextTime;
    private float healNextTime;
    private float reviveNextTime;

    void Update()
    {
        // Handle cooldowns or other update-related tasks specific to Saint
    }

    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSkill1()
    {
        if (Time.time - barrierNextTime < barrierCooldownTime)
        {
            Debug.Log("Barrier skill is on cooldown.");
            return;
        }
        barrierNextTime = Time.time;

        Instantiate(barrierPrefab, barrierSpawn.position, barrierSpawn.rotation);
        Debug.Log("Saint is using BARRIER skill");
    }

    public override void ActivateSkill2()
    {
        if (Time.time - healNextTime < healCooldownTime)
        {
            Debug.Log("Heal skill is on cooldown.");
            return;
        }
        healNextTime = Time.time;

        HealAllAllies(healAmount);
        Debug.Log("Saint is using HEAL skill");
    }

    public override void ActivateSkill3()
    {
        if (Time.time - reviveNextTime < reviveCooldownTime)
        {
            Debug.Log("Revive skill is on cooldown.");
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
        Debug.Log("Saint is healing all allies with amount: " + amount);
    }

    private void ReviveFallenAlly()
    {
        // Implement the logic to revive a fallen ally
        Debug.Log("Saint is reviving a fallen ally");
    }
}
