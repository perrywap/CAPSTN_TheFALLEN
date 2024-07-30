using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkill1 : SkillBase
{
    [Header("Dash Settings")]
    [SerializeField] private float tumbleForce = 25f;
    public bool isTumbling;

    public override void ActivateSkill()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isAttacking ||
            !GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded) { return; }

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("tumble");

        Tumble();
    }

    private void Tumble()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.localScale.x * -tumbleForce, 0f);
        StartCoroutine(SkillOnCoolDown());
        StartCoroutine(ModifyRBVelocity());
    }

    private IEnumerator ModifyRBVelocity()
    {
        yield return new WaitForSeconds(.2f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
    }
}
