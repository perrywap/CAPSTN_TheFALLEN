using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSkill1 : SkillBase
{
    [SerializeField] private bool isFloating;
    [SerializeField] private float floatMoveSpeed;
    private float movementInputDirection;

    private void Update()
    {
        FloatMoveInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void FloatMoveInput()
    {
        if (isFloating)
        {
            movementInputDirection = Input.GetAxisRaw("Horizontal");
        }
    }

    public override void ActivateSkill()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isFloating", true);

        StartCoroutine(launch());
    }

    private void ApplyMovement()
    {
        if (isFloating)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(movementInputDirection * floatMoveSpeed, 0f);
        }
    }

    private IEnumerator launch()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(movementInputDirection * floatMoveSpeed,
             GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y + 20f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        yield return new WaitForSeconds(.5f);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(movementInputDirection * floatMoveSpeed, 0f);
        StartCoroutine(floatDuration());
    }

    private IEnumerator floatDuration()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

        isFloating = true;

        yield return new WaitForSecondsRealtime(3f);
        isFloating = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isFloating", isFloating); 

    }
}
