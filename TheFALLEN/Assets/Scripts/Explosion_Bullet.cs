using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Bullet : MonoBehaviour
{
    public float Speed = 4.5f;
    [SerializeField] private Explosion_Radius explosionRadi;
    [SerializeField] Transform Spawn;
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //deal damage script here?
        Instantiate(explosionRadi, Spawn.position, transform.rotation);
        Destroy(gameObject);
    }
}
