using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField] private Transform impalePoint;
    [SerializeField] private float impaleDamageAmount;
    [SerializeField] private float impactDamageAmount;

    [SerializeField] private float hitBoxRadius;
    [SerializeField] private Transform hitBoxPos;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float damage;

    private void Start()
    {
        StartCoroutine(DisposeSpear());
    }

    private void Update()
    {
        CheckAttackHitBox();
    }

    private IEnumerator DisposeSpear()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    }

    private IEnumerator DelayedDisposeSpear()
    {
        yield return new WaitForSecondsRealtime(.5f);
        Destroy(gameObject);
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(hitBoxPos.position, hitBoxRadius, layer);

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.SendMessage("Damage", damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitBoxPos.position, hitBoxRadius);
    }
}
