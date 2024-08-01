using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaintSkill2 : SkillBase
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private float healAmount;

    private void FixedUpdate()
    {
        characters = CharacterSwitchManager.Instance.playerPrefabs;
    }

    public override void ActivateSkill()
    {
        if (canUseSkill && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("heal");
            StartCoroutine(ModifyRBVelocity());

            for (int i = 0; i < characters.Length; i++)
            {
                if (i == 4)
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Health += healAmount;
                else
                    characters[i].GetComponent<Player>().Health += healAmount;
            }
        }  
    }

    private IEnumerator ModifyRBVelocity()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        StartCoroutine(SkillOnCoolDown());
    }
}