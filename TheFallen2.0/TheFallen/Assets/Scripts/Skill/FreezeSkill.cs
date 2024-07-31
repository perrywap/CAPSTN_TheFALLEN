using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSkill : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DisposeGO());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            StartCoroutine(FreezeEnemies(enemy));
        }
    }

    private IEnumerator DisposeGO()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private IEnumerator FreezeEnemies(Enemy enemy)
    {
        enemy.gameObject.GetComponent<EnemyState>().canMove = false;
        yield return new WaitForSeconds(2.5f);
        enemy.gameObject.GetComponent<EnemyState>().canMove = true;

    }
}
