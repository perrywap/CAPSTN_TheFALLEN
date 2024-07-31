using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    [SerializeField] private Transform attackHitBoxPos;
    [SerializeField] private float hitBoxRadius;
    [SerializeField] private float attackInterval;
    [SerializeField] private LayerMask playerLayerMask;

    private Animator anim;

    public float attackDamage;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackHitBoxPos.position, hitBoxRadius, playerLayerMask);

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.SendMessage("TakeDamage", attackDamage);
        }
    }

    private void FinishAttack()
    {
        anim.SetBool("canAttack", false);
        StartCoroutine(StartAttackInterval());
    }

    private IEnumerator StartAttackInterval()
    {
        yield return new WaitForSeconds(attackInterval);
        anim.SetBool("canAttack", true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitBoxPos.position, hitBoxRadius);
    }
}
