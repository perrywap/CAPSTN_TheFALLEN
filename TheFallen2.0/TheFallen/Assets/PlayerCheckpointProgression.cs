using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpointProgression : MonoBehaviour
{
    public CharacterSwitchManager characterSwitchManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform playerTransform = collision.transform;

            characterSwitchManager.SwitchUpdate(playerTransform);
        }
    }
}
