using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip : MonoBehaviour
{
    public GameObject skip;
    public GameObject enablePlayer;

    // Start is called before the first frame update
    void Start()
    {
        skip.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skipIntro()
    {
        if (skip != null)
        {
            skip.SetActive(false);
            enablePlayer.SetActive(true);
        }
    }
}
