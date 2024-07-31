using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class HeroSkill3 : SkillBase
{
    [SerializeField] private float skillRadius;
    [SerializeField] private Transform hitBoxPosition;
    [SerializeField] private LayerMask WhatIsDamageable;
    public float attackDamage;

    public override void ActivateSkill()
    {
        if(canUseSkill)
        {
            StartCoroutine(ModifyRBVelocity());
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("isUsingAura");
            ApplyKnockBack();
        }
    }

    public void ApplyKnockBack()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(hitBoxPosition.position, skillRadius, WhatIsDamageable);

        foreach (Collider2D collider in detectedObjects)
        {
            float[] knockbackForce = { 10f, 30f };
            collider.transform.SendMessage("KnockBack", knockbackForce);
            collider.transform.SendMessage("Damage", attackDamage);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitBoxPosition.position, skillRadius);
    }

    private IEnumerator ModifyRBVelocity()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        StartCoroutine(SkillOnCoolDown());
    }
}
