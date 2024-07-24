using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerSkill1 : SkillBase
{
    public override void ActivateSkill()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isLaunching", true);
    }
}
