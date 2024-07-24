using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lancer : Player
{
    float launchTime;
    float launchDuration = 1f;
    float airTime = 2f;
    float moveDirection;

    private void Update()
    {
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
    }

    private void UpdateAnimation()
    {
        this.GetComponent<Animator>().SetBool("isGrounded", this.GetComponent<Player>().isGrounded);
    }
    public void Launch()
    {
        launchTime = Time.time;

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 50f);

        this.GetComponent<Animator>().SetBool("isLaunching", false);
        this.GetComponent<Animator>().SetTrigger("jumpHigh");
        StartCoroutine(LaunchTimer());
    }

    private IEnumerator LaunchTimer()
    {
        //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForSeconds(launchDuration);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
        StartCoroutine(AirMove());
    }

    private IEnumerator AirMove()
    {
        yield return new WaitForSeconds(airTime);
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
