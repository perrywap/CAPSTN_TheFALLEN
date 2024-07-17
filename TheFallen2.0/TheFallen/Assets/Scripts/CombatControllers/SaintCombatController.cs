using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaintCombatController : CombatController
{
    private Saint saint;

    private void Start()
    {
        saint = GetComponent<Saint>();
    }

    public override void CheckCombatInput()
    {
        if (saint.isAttacking)
        {
            saint.canMove = false;
            return;
        }
        else
        {
            saint.canMove = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            saint.canMove = false;
            saint.isAttacking = true;
            saint.ActivateSkill1();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            saint.ActivateSkill2();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            saint.ActivateSkill3();
        }
    }
}
