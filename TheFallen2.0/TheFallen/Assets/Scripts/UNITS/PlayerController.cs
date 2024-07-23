using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    private float movementInputDirection;
    private Rigidbody2D rb;
    private Animator anim;
    private int amountOfJumpsLeft;    

    [Header("Movement Values")]
    public float moveSpeed = 10f;
    public float jumpForce = 16f;
    public float groundCheckRadius;
    public float airDragMultiplier = 0.95f;
    public float variableJumpHeightMultiplier = 0.5f;
    public float movementForceInAir;
    public int amountOfJumps = 1;

    [Header("References")]
    public Transform groundCheck;
    public LayerMask whatIsGround;

    #endregion

    #region UNITY FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
        anim = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Player>().isUsingSkill)
            return;
            

        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        
    }

    private void FixedUpdate()
    {
        CheckSurroundings();
        if (this.GetComponent<Player>().isUsingSkill)
            return;

        ApplyMovement();        
    }
    #endregion

    #region PRIVATE FUNCTIONS
    private void CheckSurroundings()
    {
        this.GetComponent<Player>().isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void CheckIfCanJump()
    {
        if (this.GetComponent<Player>().isGrounded && rb.velocity.y <= 0f)
        {
            amountOfJumpsLeft = amountOfJumps;
        }
        
        if (amountOfJumpsLeft <= 0f)
        {
            this.GetComponent<Player>().canJump = false;
        }
        else
        {
            this.GetComponent<Player>().canJump = true;
        }
    }
    
    private void CheckMovementDirection()
    {
        if (this.GetComponent<Player>().isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if (!this.GetComponent<Player>().isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if(Mathf.Abs(rb.velocity.x) >= 0.01f)
        {
            this.GetComponent<Player>().isWalking = true;
        }
        else
        {
            this.GetComponent<Player>().isWalking = false;  
        }
    }
    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", this.GetComponent<Player>().isWalking);
        anim.SetBool("isGrounded", this.GetComponent<Player>().isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);  
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
        }
    }

    private void Jump()
    {
        if (this.GetComponent<Player>().canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
        }
    }
    private void ApplyMovement()
    {
        // STATIONARY JUMP
        if (!this.GetComponent<Player>().isGrounded && movementInputDirection == 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
        }

        // WALK
        else if (this.GetComponent<Player>().isGrounded && this.GetComponent<Player>().canMove)
        {
            rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y);
        }
        else if (this.GetComponent<Player>().isGrounded && !this.GetComponent<Player>().canMove)
        {
            rb.velocity = Vector2.zero;
        }

        //MOVE LEFT OR RIGHT WHILE JUMPING
        else if (!this.GetComponent<Player>().isGrounded && movementInputDirection != 0)
        {
            Vector2 forceToAdd = new Vector2(movementForceInAir * movementInputDirection, 0);
            rb.AddForce(forceToAdd);

            if(Mathf.Abs(rb.velocity.x) > moveSpeed)
            {
                rb.velocity = new Vector2(moveSpeed * movementInputDirection, rb.velocity.y);
            }
        }
    }

    private void Flip()
    {
        this.GetComponent<Player>().isFacingRight = !this.GetComponent<Player>().isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    #endregion
}