using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //player.gameObject.SetActive(false);
            CheckpointManager.Instance.RespawnPlayer();
        }
    }
}
