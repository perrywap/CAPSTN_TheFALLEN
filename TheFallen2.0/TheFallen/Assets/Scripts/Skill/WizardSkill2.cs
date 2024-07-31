using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardSkill2 : SkillBase
{
    [SerializeField] private GameObject freezePrefab;
    [SerializeField] private Transform freezeSpawnPos;

    private GameObject freezeGO;

    public override void ActivateSkill()
    {
        if (canUseSkill && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isFacingRight)
            {
                freezeGO = Instantiate(freezePrefab, freezeSpawnPos.position, Quaternion.identity);
            }
            else
                freezeGO = Instantiate(freezePrefab, freezeSpawnPos.position, Quaternion.Euler(0, 180, 0));

            StartCoroutine(ModifyRBVelocity());
        }
    }

    private IEnumerator ModifyRBVelocity()
    {
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        StartCoroutine(SkillOnCoolDown());
    }
}
