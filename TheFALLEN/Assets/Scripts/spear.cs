using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{
    [SerializeField] private float spearSpeed = 10f;
    [SerializeField] private int damage = 10;
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * spearSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the bullet hits an enemy
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // Destroy the bullet after it hits something
        Destroy(gameObject);
    }
}
