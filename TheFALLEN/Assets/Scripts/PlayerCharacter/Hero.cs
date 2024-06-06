using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Player
{
    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Hero is using DASH skill");
    }

    public override void ActivateLightSkill()
    {
        Debug.Log("Hero is using BLOCK skill");
    }

    public override void ActivateHeavySkill()
    {
        Debug.Log("Hero is using AURA skill");
    }

    public override void ActivateUltimateSkill()
    {
        Debug.Log("Hero is using DIVINE JUDGEMENT skill");
    }
    #endregion
}