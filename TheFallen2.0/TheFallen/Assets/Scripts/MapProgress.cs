using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapProgress : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private GameObject fader;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null )
        {
            fader.GetComponent<Animator>().Play("FadeOut");
            StartCoroutine(NextMap());
        }
    }

    private IEnumerator NextMap()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(sceneIndex);
    }
}
