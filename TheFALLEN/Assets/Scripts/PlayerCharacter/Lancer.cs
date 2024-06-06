using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lancer : Player
{
    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Lancer is using HIGH JUMP skill");
    }

    public override void ActivateLightSkill()
    {
        Debug.Log("Lancer is using THRUST skill");
    }

    public override void ActivateHeavySkill()
    {
        Debug.Log("Lancer is using MUTILATE skill");
    }

    public override void ActivateUltimateSkill()
    {
        Debug.Log("Lancer is using MANA SPEAR skill");
    }
    #endregion
}
