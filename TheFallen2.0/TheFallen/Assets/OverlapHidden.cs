using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapHidden : MonoBehaviour
{
    [SerializeField] private GameObject HiddenPlatforms;
    [SerializeField] private GameObject TrapDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HiddenPlatforms.SetActive(true);
            TrapDoor.SetActive(false);
        }
    }
}
