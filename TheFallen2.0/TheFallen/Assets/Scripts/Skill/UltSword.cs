using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltSword : MonoBehaviour
{
    [SerializeField] private float damage;

    private void Start()
    {
        StartCoroutine(DestroySword());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    
        if (enemy != null )
        {
            Debug.Log("Enemy should be dead");
            enemy.transform.SendMessage("Damage", damage);
        }
    }

    private IEnumerator DestroySword()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        Destroy(gameObject);
    }
}