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

    [Header("Support Skill")]
    [SerializeField] private float _supportSkillCooldown;
    [SerializeField] private bool _canUseSupportSkill;

    [Header("Light Skill")]
    [SerializeField] private float _lightSkillCooldown;
    [SerializeField] private bool _canUseLightSkill;

    [Header("Heavy Skill")]
    [SerializeField] private float _heavySkillCooldown;
    [SerializeField] private bool _canUseheavySkill;

    [Header("Ultimate Skill")]
    [SerializeField] private float _ultiSkillCooldown;
    [SerializeField] private bool _canUseUltiSkill;

    private Animator _animator;

    [Header("Booleans")]
    [SerializeField] private bool _isDead;
    [SerializeField] private bool _isJumping;
    [SerializeField] private bool _isFalling;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isAttacking;
    [SerializeField] private bool _isUsingSkill;
    [SerializeField] private bool _isMoving;
    [SerializeField] private bool _canMove;
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
    public bool CanMove 
    { 
        //get 
        //{
        //    _canMove = _animator.GetBool("canMove");
        //    return _animator.GetBool("canMove"); 
        //} 
        get { return _canMove; } set { _canMove = value; }
    }

    public float SupportSkillCooldown { get {  return _supportSkillCooldown; } set { _supportSkillCooldown = value; } }
    public bool CanUseSupportSkill { get {  return _canUseSupportSkill; } set { _canUseSupportSkill = value; } }

    public float LightSkillCooldown { get { return _lightSkillCooldown; } set { _lightSkillCooldown = value; } }
    public bool CanUseLightSkill { get { return _canUseLightSkill; } set { _canUseLightSkill = value; } }
    public float HeavySkillCooldown { get { return _heavySkillCooldown; } set { _heavySkillCooldown = value; } }
    public bool CanUseHeavySkill { get { return _canUseheavySkill; } set { _canUseheavySkill = value; } }
    public float UltimateSkillCooldown { get { return _ultiSkillCooldown; } set { _ultiSkillCooldown = value; } }
    public bool CanUseUltiSkill { get { return _canUseUltiSkill;} set {  _canUseUltiSkill = value;} }
    #endregion

    #region UNITY FUNCTIONS
    private void Start()
    {
        CanMove = true;
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
