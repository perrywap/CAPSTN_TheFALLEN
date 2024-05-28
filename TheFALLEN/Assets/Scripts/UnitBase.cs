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

    [Header("Booleans")]
    [SerializeField] private bool _isDead;
    [SerializeField] private bool _isJumping;
    [SerializeField] private bool _isFalling;
    #endregion

    #region GETTERS & SETTERS
    public float Health {get { return _health; } set { _health = value; } }
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float AttackPoints { get { return _attackPoints; } set { _attackPoints = value; } }
    public float DefensePoints { get { return _defensePoints; } set { _defensePoints = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public bool IsDead { get { return _isDead; } set { _isDead = value; } }
    public bool IsJumping { get { return _isJumping; } set { _isJumping = value; } }
    public bool IsFalling { get { return _isFalling; } set { _isFalling = value; } }
    #endregion

    #region UNITY FUNCTIONS
    private void Start()
    {
        
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
