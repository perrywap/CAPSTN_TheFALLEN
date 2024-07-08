using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player
{
    [SerializeField] private float LightSkillCoolDownTime;
    [SerializeField] private float LightSkillNextTime;
    [SerializeField] private float LightSkillActiveTime;
    [SerializeField] private float LightSkillOffTime;
    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Wizard is using FLOAT skill");
        if (Time.time - LightSkillNextTime < LightSkillCoolDownTime)
        {
            return;
        }
        LightSkillNextTime = Time.time;

        Rigidbody2d rb2d = GetComponent<Rigidbody2D>();
        rb2d.enabled = false;
        if (Time.time - LightSkillActiveTime < LightSkillOffTime)
        {
            rb2d.enabled = true;
        }

        
    }

    public override void ActivateLightSkill()
    {
        Debug.Log("Wizard is using FREEZE skill");
    }

    public override void ActivateHeavySkill()
    {
        Debug.Log("Wizard is using FLAME skill");
    }

    public override void ActivateUltimateSkill()
    {
        Debug.Log("Wizard is using BLACK HOLE skill");
    }
    #endregion
}
