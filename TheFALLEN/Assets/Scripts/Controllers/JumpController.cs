using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    #region VARIABLES
    private Rigidbody2D rb;
    private Vector2 _vecGravity;

    [SerializeField] private float _jumpTime;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _jumpMultiplier;
    [SerializeField] private float _fallMultiplier;
    private float _jumpCounter;


    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    #endregion

    //JumpController jumpEnabled;

    #region UNITY FUNCTIONS
    private void Start()
    {
        _vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();

        //jumpEnabled = GetComponent<JumpController>();
    }

    private void Update()
    {
        //jumpEnabled.enabled = false;

        IsGrounded();
        Jump();
        
        
    }
    #endregion

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("cutsceneTrigger") == true)
    //    {
    //        jumpEnabled.enabled = false;
    //    }
            
    //}

    #region PRIVATE FUNCTIONS
    private void Jump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) 
            && IsGrounded() && this.GetComponent<Player>().CanMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpPower);
            this.GetComponent<Player>().IsJumping = true;
            _jumpCounter = 0;
        }

        if (rb.velocity.y > 0 && this.GetComponent<Player>().IsJumping)
        {
            _jumpCounter += Time.deltaTime;
            if (_jumpCounter > _jumpTime)
            {
                this.GetComponent<Player>().IsJumping = false;
            }

            float t = _jumpCounter / _jumpTime;
            float currentJumpM = _jumpMultiplier;

            if (t > 0.5f)
            {
                currentJumpM = _jumpMultiplier * currentJumpM * Time.deltaTime;
            }

            rb.velocity += _vecGravity * _jumpMultiplier * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W))
        {
            this.GetComponent<Player>().IsJumping = false;
            _jumpCounter = 0f;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= _vecGravity * _fallMultiplier * Time.deltaTime;
            this.GetComponent<Player>().IsFalling = true;
        }
    }
    private bool IsGrounded()
    {
        this.GetComponent<Player>().IsFalling = false;
        this.GetComponent<Player>().IsGrounded = Physics2D.OverlapCapsule(_groundCheck.position, new Vector2(1.05f, 0.05f),
            CapsuleDirection2D.Horizontal, 0, _groundLayer);
        
        return this.GetComponent<Player>().IsGrounded;
    }
    #endregion
}
