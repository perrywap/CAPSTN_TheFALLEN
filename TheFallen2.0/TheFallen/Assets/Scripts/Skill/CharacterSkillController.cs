using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkillController : MonoBehaviour
{
    public SkillBase[] skills;

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (skills[0] == null)
                return;

            skills[0].ActivateSkill();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (skills[1] == null)
                return;

            skills[1].ActivateSkill();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (skills[2] == null)
                return;
            
            skills[2].ActivateSkill();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (skills[3] == null)
                return;

            skills[3].ActivateSkill();
        }
    }
}
