using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player
{
    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Wizard is using FLOAT skill");
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
