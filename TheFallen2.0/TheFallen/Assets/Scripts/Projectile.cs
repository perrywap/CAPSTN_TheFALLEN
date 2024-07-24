using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    [SerializeField] private float attack1Radius;
    [SerializeField] private Transform hitBoxPos;
    [SerializeField] private LayerMask WhatIsDamageable;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().character == Character.ARCHER)
            damageAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<ArcherCombatController>().attackDamage;

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().character == Character.WIZARD ||
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().character == Character.SAINT)
            damageAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<MagesCombatController>().attackDamage;

        StartCoroutine(DisposeProjectile());
    }

    private void Update()
    {
        CheckAttackHitBox();
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(hitBoxPos.position, attack1Radius, WhatIsDamageable);

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.SendMessage("Damage", damageAmount);
            Destroy(gameObject);
        }
    }

    private IEnumerator DisposeProjectile()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitBoxPos.position, attack1Radius);
    }
}
