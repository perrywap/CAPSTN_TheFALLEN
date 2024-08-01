using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private GameObject player;
    [SerializeField] private float barrierDuration;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isBarrierActive = true;
        StartCoroutine(StartBarrierDecay());
    }

    private void Update()
    {
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isBarrierActive = false;
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = player.transform.position;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }

    private IEnumerator StartBarrierDecay()
    {
        yield return new WaitForSeconds(barrierDuration);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isBarrierActive = false;
        Destroy(gameObject);
    }
}
