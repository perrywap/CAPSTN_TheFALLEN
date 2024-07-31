using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardSkill2 : SkillBase
{
    [SerializeField] private GameObject freezePrefab;
    [SerializeField] private Transform freezeSpawnPos;
    [SerializeField] private bool isUsingFreeze;

    private GameObject freezeGO;

    private void FixedUpdate()
    {
        if (isUsingFreeze)
        {
            SpawnFreeze();
            isUsingFreeze = false;
        }
    }

    public override void ActivateSkill()
    {
        if (canUseSkill && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("freeze");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

            StartCoroutine(ModifyRBVelocity());
        }
    }

    private void SpawnFreeze()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isFacingRight)
        {
            freezeGO = Instantiate(freezePrefab, freezeSpawnPos.position, Quaternion.identity);
        }
        else
            freezeGO = Instantiate(freezePrefab, freezeSpawnPos.position, Quaternion.Euler(0, 180, 0));
    }

    private IEnumerator ModifyRBVelocity()
    {
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        StartCoroutine(SkillOnCoolDown());
    }
}
