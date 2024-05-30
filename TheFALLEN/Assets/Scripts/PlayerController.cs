using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class Player_Controller : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb; //rigid body of the player character
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer; //make sure all platforms are in this layer

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
=======
public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _horizontal;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _jumpPeak;
    [SerializeField] private bool _isFacingRight = true;

    [SerializeField] private Rigidbody2D _rigidbody2d; //rigid body of the player character
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer; //make sure all platforms are in this layer

    float tempJumpPeak = 0f;
    #endregion


    #region UNITY FUNCTIONS
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_rigidbody2d.velocity.y);
        Move();
        Jump();
>>>>>>> Stashed changes
        BaseAtk();
        Skill1();
        Skill2();
        Skill3();
        Skill4();
        CharaSwap1();
        CharaSwap2();
        CharaSwap3();
        CharaSwap4();
        CharaSwap5();
    }

    private void FixedUpdate()
    {
<<<<<<< Updated upstream
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
      
    }
=======
        _rigidbody2d.velocity = new Vector2(_horizontal * _jumpSpeed, _rigidbody2d.velocity.y);
      
    }
    #endregion

    private void Move()
    {
        if (this.GetComponent<Player>().IsJumping)
            return;

        _horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpPower);   
        }

        if (Input.GetButtonDown("Jump") && _rigidbody2d.velocity.y > 0f)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _rigidbody2d.velocity.y * 0.5f);
        }
    }
>>>>>>> Stashed changes

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
<<<<<<< Updated upstream
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
=======
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
>>>>>>> Stashed changes
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void BaseAtk()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //call basic attack function here
            Debug.Log("Attack!");
        }
    }

    private void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //call skill 1 function here
            Debug.Log("skill 1 active");
        }
    }
    private void Skill2()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //call skill 2 function here
            Debug.Log("skill 2 active");
        }
    }
    private void Skill3()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //call skill 3 function here
            Debug.Log("skill 3 active");
        }
    }
    private void Skill4()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //call skill 4 function here
            Debug.Log("skill 4 active");
        }
    }

    private void CharaSwap1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //call Hero Swap function
            Debug.Log("Hero Active");
        }
    }
    private void CharaSwap2()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //call Lancer Swap Function
            Debug.Log("Lancer Active");
        }
    }
    private void CharaSwap3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //call Archer Swap Function
            Debug.Log("Archer Active");
        }
    }
    private void CharaSwap4()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //call Wizard Swap Function
            Debug.Log("Wizard Active");
        }
    }
    private void CharaSwap5()
<<<<<<< Updated upstream
    {
=======
    { 
>>>>>>> Stashed changes
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //call Saint Swap Function
            Debug.Log("Saint Active");
        }
    }
}