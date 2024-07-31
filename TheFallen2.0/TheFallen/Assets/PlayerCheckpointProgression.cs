using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpointProgression : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            CheckpointManager.Instance.currentCheckpoint = this.transform;
            Debug.Log("Current checkpoint is " + this.name);
        }
    }
}
