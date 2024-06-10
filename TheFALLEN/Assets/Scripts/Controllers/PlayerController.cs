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
    [SerializeField] private bool _isFacingRight;

    [SerializeField] private Rigidbody2D _rigidbody2d; //rigid body of the player character
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer; //make sure all platforms are in this layer
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
        Flip();
        BaseAtk();
        UseSkill();
        CharacterSwap();
    }

    private void FixedUpdate()
    {
         _rigidbody2d.velocity = new Vector2(_horizontal * _jumpSpeed, _rigidbody2d.velocity.y);
    }
    #endregion

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
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

    private void UseSkill()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            this.GetComponent<Player>().IsUsingSkill = true;
            this.GetComponent<Player>().ActivateSupportSkill();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            this.GetComponent<Player>().IsUsingSkill = true;
            this.GetComponent<Player>().ActivateLightSkill();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            this.GetComponent<Player>().IsUsingSkill = true;
            this.GetComponent<Player>().ActivateHeavySkill();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            this.GetComponent<Player>().IsUsingSkill = true;
            this.GetComponent<Player>().ActivateUltimateSkill();
        }
    }

    private void CharacterSwap()
    {
        if(this.GetComponent<Player>().IsGrounded && !this.GetComponent<Player>().IsAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //call Hero Swap function
                Debug.Log("Switched to HERO");
                CharacterSwitchManager.Instance.ChangeCharacter(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //call Lancer Swap function
                Debug.Log("Switched to LANCER");
                CharacterSwitchManager.Instance.ChangeCharacter(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //call Archer Swap function
                Debug.Log("Switched to ARCHER");
                CharacterSwitchManager.Instance.ChangeCharacter(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                //call Wizard Swap function
                Debug.Log("Switched to WIZARD");
                CharacterSwitchManager.Instance.ChangeCharacter(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                //call Saint Swap function
                Debug.Log("Switched to SAINT");
                CharacterSwitchManager.Instance.ChangeCharacter(4);
            }
        }
    }
}