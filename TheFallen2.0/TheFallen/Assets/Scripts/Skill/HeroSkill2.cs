using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkill2 : SkillBase
{
    public bool isBlocking;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            isBlocking = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isBlocking", true);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            isBlocking = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isBlocking", false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        }
    }

    public override void ActivateSkill()
    {
        isBlocking = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isBlocking", true);
    }
}
