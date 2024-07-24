using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField] private float impaleDamageAmount;
    [SerializeField] private float impactDamageAmount;

    private void Start()
    {
        
    }

    private IEnumerator DisposeSpear()
    {
        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {

        }
    }
}
