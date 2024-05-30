using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SwitchScenes : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collide");
            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("change level");
                Load();
            }
        }
    }
    public void Load()
    {
        //for printing scene count/number

        if(gameObject.CompareTag("level1CheckpointEnd"))
        {
            //SceneManager.LoadScene(1, LoadSceneMode.Single); //loads level 2
            SceneManager.LoadScene("testLevel2", LoadSceneMode.Single);
        }
        if (gameObject.CompareTag("level2CheckpointFront"))
        {
            //SceneManager.LoadScene(0, LoadSceneMode.Single); //loads level 1
            SceneManager.LoadScene("testLevel1", LoadSceneMode.Single);
        }
    }
}
