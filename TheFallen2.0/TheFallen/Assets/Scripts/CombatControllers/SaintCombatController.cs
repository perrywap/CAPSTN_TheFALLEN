using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaintCombatController : CombatController
{
    private Saint saint;

    protected override void Start()
    {
        base.Start();  // Call the base class Start method

        saint = GetComponent<Saint>();

        // Ensure the AudioSource component is assigned
        if (attackSound == null)
        {
            attackSound = GetComponent<AudioSource>();
        }
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

            // Play the attack sound
            if (attackSound != null)
            {
                attackSound.Play();
            }
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
