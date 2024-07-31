using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null )
        {
            enemy.transform.SendMessage("Damage", damageAmount);
            StartCoroutine(Dispose());
        }
    }

    private IEnumerator Dispose()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
