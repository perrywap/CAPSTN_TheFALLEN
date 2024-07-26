using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LancerFallImpact : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void Start()
    {
        StartCoroutine(DestroyCounter());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null )
        {
            enemy.transform.SendMessage("Damage", damageAmount);
        }
    }

    private IEnumerator DestroyCounter()
    {
        yield return new WaitForSeconds(.25f);
        Destroy(gameObject);
    }
}
