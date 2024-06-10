using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saint : Player
{
    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Saint is using BARRIER skill");
    }

    public override void ActivateLightSkill()
    {
        Debug.Log("Saint is using HEAL skill");
    }

    public override void ActivateHeavySkill()
    {
        Debug.Log("Saint is using DEBUFF skill");
    }

    public override void ActivateUltimateSkill()
    {
        Debug.Log("Saint is using REVIVE skill");
    }
    #endregion
}
