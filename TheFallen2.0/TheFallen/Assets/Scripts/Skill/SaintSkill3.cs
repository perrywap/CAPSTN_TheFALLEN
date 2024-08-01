using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaintSkill3 : SkillBase
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private float healAmount;// If all is alive, heal a small amount instead

    private void FixedUpdate()
    {
        characters = CharacterSwitchManager.Instance.playerPrefabs;
    }

    public override void ActivateSkill()
    {
        if (canUseSkill && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("revive");
            StartCoroutine(ModifyRBVelocity());
            Revive();
        }
    }

    private void Revive()
    {
        int aliveCounter = 0;

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].GetComponent<Player>().isDead)
            {
                characters[i].GetComponent<Player>().isDead = false;
                characters[i].GetComponent<Player>().Health = characters[i].GetComponent<Player>().MaxHealth;
                break;
            }
            else
                aliveCounter++;
        }

        if (aliveCounter == 5)
        {
            SmallHeal();
        }

    }

    private void SmallHeal()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == 4)
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Health += healAmount;
            else
                characters[i].GetComponent<Player>().Health += healAmount;
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
