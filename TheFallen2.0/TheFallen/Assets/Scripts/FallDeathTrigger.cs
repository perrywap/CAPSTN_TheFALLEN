using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //insert on death function here

            //insert respawn here
        }
    }
}
