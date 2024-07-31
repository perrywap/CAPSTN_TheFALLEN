using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerFallLocation : MonoBehaviour
{
    private GameObject player;


    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        this.transform.position = new Vector2(player.transform.position.x, this.transform.position.y);

        if (!player.GetComponent<Animator>().GetBool("isAirMoving"))
        {
            Destroy(gameObject);
        }
    }
}
