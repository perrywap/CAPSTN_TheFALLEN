using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float _horizontal;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isFacingRight;

    [SerializeField] private Rigidbody2D _rigidbody2d; //rigid body of the player character
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer; //make sure all platforms are in this layer
    [SerializeField] private PlayerCharacter _activeCharacter;
    #endregion

    #region GETTERS AND SETTERS
    public float Horizontal { get { return _horizontal; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public Rigidbody2D Rb2D { get { return _rigidbody2d; } set { _rigidbody2d = value; } }
    #endregion

    #region UNITY FUNCTIONS
    // Update is called once per frame
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _activeCharacter = this.GetComponent<Player>().Character;

        if(_activeCharacter == PlayerCharacter.HERO) 
        {
            if (this.GetComponent<Hero>().IsDashing) { return; }
        }


        Move();
        Flip();
        BaseAtk();
        UseSkill();
        CharacterSwap();
    }

    private void FixedUpdate()
    {
        if (_activeCharacter == PlayerCharacter.HERO)
        {
            if (this.GetComponent<Hero>().IsDashing) { return; }
        }

        if (this.GetComponent<Player>().CanMove)
        {
            _rigidbody2d.velocity = new Vector2(_horizontal * _moveSpeed, _rigidbody2d.velocity.y);
        }
        else
            _rigidbody2d.velocity = Vector2.zero;
    }
    #endregion

    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (_horizontal > 0f || _horizontal < 0f)
        {
            this.GetComponent<Player>().IsMoving = true;
        }
        else
        {
            this.GetComponent<Player>().IsMoving = false;
        }
        
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
            this.GetComponent<Player>().IsAttacking = true;
            this.GetComponent<Player>().CanMove = false;
            Debug.Log("Attack!");
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            //call basic attack function here
            this.GetComponent<Player>().IsAttacking = false;
            this.GetComponent<Player>().CanMove = true;
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