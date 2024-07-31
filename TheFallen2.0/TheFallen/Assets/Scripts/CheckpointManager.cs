using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject player;

    public Transform currentCheckpoint;
    public static CheckpointManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentCheckpoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCounter());
    }

    private IEnumerator RespawnCounter()
    {
        //player.SetActive(true);
        yield return new WaitForSeconds(.5f);
        player.transform.position = currentCheckpoint.position;
    }
}
