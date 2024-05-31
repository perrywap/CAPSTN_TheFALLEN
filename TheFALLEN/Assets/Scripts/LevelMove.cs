using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    [SerializeField] private int _sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null )
        {
            SceneManager.LoadScene(_sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
