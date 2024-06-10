using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string triggererTag = "Player";
    public string playerSpawnTransformName = "NOT SET";
    public float enterSpeed = 1f;
    public SceneAsset sceneToLoad;
    public GameObject fadeAnimation;

    private Canvas canvas;
    private Animator transitionAnimator;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();

        if(sceneToLoad == null)
        {
            throw new MissingComponentException(name + " has no sceneToLoad set");
        }

        if(fadeAnimation == null)
        {
            throw new MissingComponentException(name + " has no fadeAnimation set for the transition");
        }
    }

    private void Update()
    {
        if(transitionAnimator != null) 
        {
            if(transitionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) 
            {
                LevelEvents.levelExit.Invoke(sceneToLoad, playerSpawnTransformName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D playerBody = collision.GetComponent<Rigidbody2D>();
        playerBody.bodyType = RigidbodyType2D.Kinematic;

        Vector2 entranceDirection = (transform.position - playerBody.transform.position).normalized;

        playerBody.velocity = entranceDirection * enterSpeed;

        transitionAnimator = Instantiate(fadeAnimation, canvas.transform).GetComponent<Animator>();
    }
}
