using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SaintSkill1 : SkillBase
{
    [SerializeField] private GameObject barrierPrefab;

    public override void ActivateSkill()
    {
        if (canUseSkill && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("engageBarrier");
            StartCoroutine(ModifyRBVelocity());
            GameObject barrierGO = Instantiate(barrierPrefab, this.transform.position, Quaternion.identity);
            Barrier barrier = barrierGO.GetComponent<Barrier>();
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
