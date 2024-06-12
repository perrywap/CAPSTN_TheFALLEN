using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitBase : MonoBehaviour
{

    #region VARIABLES
    [Header("Character Stats")]
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _attackPoints;
    [SerializeField] private float _defensePoints;
    [SerializeField] private float _attackSpeed;

    private Animator _animator;

    [Header("Booleans")]
    [SerializeField] private bool _isDead;
    [SerializeField] private bool _isJumping;
    [SerializeField] private bool _isFalling;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isAttacking;
    [SerializeField] private bool _isUsingSkill;
    [SerializeField] private bool _isMoving;
    #endregion

    #region GETTERS & SETTERS
    public float Health { get { return _health; } set { _health = value; } }
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float AttackPoints { get { return _attackPoints; } set { _attackPoints = value; } }
    public float DefensePoints { get { return _defensePoints; } set { _defensePoints = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public bool IsDead 
    { 
        get { return _isDead; } 
        set 
        { 
            _isDead = value;
            _animator.SetBool("isDead", value);
        } 
    }
    public bool IsJumping 
    { 
        get { return _isJumping; } 
        set 
        { 
            _isJumping = value;
            _animator.SetBool("isJumping", value);
        } 
    }
    public bool IsFalling 
    { 
        get { return _isFalling; } 
        set 
        {
            _isFalling = value;
            _animator.SetBool("isFalling", value);
        }
    }
    public bool IsGrounded 
    { 
        get { return _isGrounded; } 
        set 
        { 
            _isGrounded = value;
            _animator.SetBool("isGrounded", value);
        }
    }
    public bool IsAttacking 
    {
        get { return _isAttacking; } 
        set 
        {
            _isAttacking = value;
            _animator.SetBool("isAttacking", value);
        }
    }
    public bool IsUsingSkill 
    { 
        get { return _isUsingSkill; } 
        set 
        {
            _isUsingSkill = value;
            _animator.SetBool("isUsingSkill", value);
        }
    }
    public bool IsMoving 
    { 
        get { return _isMoving; } 
        set 
        {
            _isMoving = value;
            _animator.SetBool("isMoving", value);
        }
    }
    #endregion

    #region UNITY FUNCTIONS
    private void Start()
    {

    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    #endregion

    #region PRIVATE FUNCTIONS
    private void TakeDamage(float damage)
    {
        // Input code for taking damage
    }

    private void Die()
    {
        IsDead = true;
    }
    #endregion

    #region OVERRIDABLE FUNCTIONS
    public virtual void Attack()
    {
        // Input unique code for attacking for corresponding character
    }

    public virtual void ActivateSupportSkill()
    {
        Debug.Log("Should use Support skill of character");
    }

    public virtual void ActivateLightSkill()
    {

    }

    public virtual void ActivateHeavySkill()
    {

    }

    public virtual void ActivateUltimateSkill()
    {

    }
    #endregion
}
