using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Player
{
    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Archer is using TUMBLE skill");
    }

    public override void ActivateLightSkill()
    {
        Debug.Log("Archer is using CHARGED SHOT skill");
    }

    public override void ActivateHeavySkill()
    {
        Debug.Log("Archer is using MAKE IT RAIN skill");
    }

    public override void ActivateUltimateSkill()
    {
        Debug.Log("Archer is using WIND RUNNER skill");
    }
    #endregion
}
