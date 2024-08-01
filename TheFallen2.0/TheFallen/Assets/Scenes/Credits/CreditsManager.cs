using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] float remainingTime;

    // Update is called once per frame
    void Update()
    {
        remainingTime = Time.deltaTime;

        TimeEnd();
    }

    void TimeEnd()
    {
        if (remainingTime <= 0) 
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
