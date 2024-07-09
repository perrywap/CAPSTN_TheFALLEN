using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] private bool combatEnabled;
    [SerializeField] private float inputTimer, attack1Radius, attack1Damage; 
    [SerializeField] private Transform attack1HitBoxPos;
    [SerializeField] private LayerMask WhatIsDamageable;

    public bool gotInput;
    public bool isAttacking;
    public bool isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity;
    [SerializeField] private int attackCount = 0;

    private Animator anim;

    private void Start()
    {
        isFirstAttack = true;
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput()
    {
        if(isAttacking)
            return;

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
                attackCount++;
            }
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                //isFirstAttack = !isFirstAttack;
                //anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);

                switch (attackCount)
                {
                    case 1:
                        {
                            anim.SetBool("attack1", true);
                            isFirstAttack = false;
                            break;
                        }
                    case 2:
                        {
                            anim.SetBool("attack1", false);
                            anim.SetBool("attack2", true);
                            isFirstAttack = false;
                            break;
                        }
                    case 3:
                        {
                            anim.SetBool("attack2", false);
                            anim.SetBool("attack3", true);
                            isFirstAttack = false;
                            break;
                        }
                    case 4:
                        {
                            anim.SetBool("attack3", false);
                            anim.SetBool("attack4", true);
                            isFirstAttack = false;

                            attackCount = 0;
                            isFirstAttack = true;
                            break;
                        }
                }
            }
        }

        if (Time.time >= lastInputTime + inputTimer) 
        {
            gotInput = false;

        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, WhatIsDamageable);

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attack1Damage);

        }
    }

    private void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
        anim.SetBool("attack2", false);
        anim.SetBool("attack3", false);
        anim.SetBool("attack4", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }
}
