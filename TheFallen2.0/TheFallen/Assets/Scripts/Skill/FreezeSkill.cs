using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSkill : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<ParticleSystem>().Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            this.GetComponent<ParticleSystem>().Play();

        }
    }
}
