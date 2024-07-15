using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public bool combatEnabled;
    [SerializeField] private float inputTimer, attack1Radius;
    public float attackDamage; 
    [SerializeField] private Transform attack1HitBoxPos;
    [SerializeField] private LayerMask WhatIsDamageable;

    public bool gotInput;
    public bool isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity;
    public int attackCount = 0;

    public Animator anim;

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

    public virtual void CheckCombatInput()
    {
        if(this.GetComponent<Player>().isAttacking)
        {
            this.GetComponent<Player>().canMove = false;
            return;
        }
        else
        {
            this .GetComponent<Player>().canMove = true;
        }

            

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
                attackCount++;
                anim.SetInteger("attackCount", attackCount);
            }
        }
    }

    public virtual void CheckAttacks()
    {
        if (gotInput)
        {
            if (!this.GetComponent<Player>().isAttacking)
            {
                gotInput = false;
                this.GetComponent<Player>().isAttacking = true;
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", this.GetComponent<Player>().isAttacking);

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
            collider.transform.parent.SendMessage("Damage", attackDamage);
        }
    }

    private void FinishAttack1()
    {
        this.GetComponent<Player>().isAttacking = false;
        anim.SetBool("isAttacking", this.GetComponent<Player>().isAttacking);
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
