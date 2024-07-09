using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Radius : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //take damage script here
        Destroy(gameObject);
    }
}
