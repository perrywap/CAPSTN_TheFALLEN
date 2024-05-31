using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _horizontal;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private bool _isFacingRight = true;

    [SerializeField] private Rigidbody2D _rigidbody2d; //rigid body of the player character
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer; //make sure all platforms are in this layer

    float tempJumpPeak = 0f;
    #endregion


    #region UNITY FUNCTIONS
    // Update is called once per frame
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Debug.Log(_rigidbody2d.velocity.y);
        Move();
        Jump();
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
         _rigidbody2d.velocity = new Vector2(_horizontal * _jumpSpeed, _rigidbody2d.velocity.y);
    }
    #endregion

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void Jump()
    {
        //if (Input.GetButtonDown("Jump") && IsGrounded())
        //{
        //    _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpPower);
        //    this.GetComponent<Player>().IsJumping = true;
        //}

        ////if (Input.GetButtonDown("Jump") && _rigidbody2d.velocity.y > 0f)
        ////{
        ////    _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _rigidbody2d.velocity.y * 0.5f);
        ////}

        //if(_rigidbody2d.velocity.y > 0 && this.GetComponent<Player>().IsJumping) 
        //{
        //    _rigidbody2d.velocity
        //}
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0f || !_isFacingRight && _horizontal > 0f)
        {
            _isFacingRight = !_isFacingRight;
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
    { 
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //call Saint Swap Function
            Debug.Log("Saint Active");
        }
    }
}
