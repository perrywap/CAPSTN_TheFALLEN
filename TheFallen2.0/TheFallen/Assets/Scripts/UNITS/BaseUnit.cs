using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    #region VARIABLES
    [Header("Character Stats")]
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _attackPoints;
    [SerializeField] private float _defensePoints;
    [SerializeField] private float _attackSpeed;

    [Header("Booleans")]
    public bool isFacingRight = true;
    public bool isWalking;
    public bool isGrounded;
    public bool isAttacking;
    public bool canJump;
    public bool canMove;

    [Header("Unit Status")]
    public bool isDead = false;

    [Header("Skill 1")]
    public float skill1CD;
    public bool canUseSkill1;

    [Header("Skill 2")]
    public float skill2CD;
    public bool canUseSkill2;

    [Header("Skill 3")]
    public float skill3CD;
    public bool canUseSkill3;
    #endregion

    #region
    public float Health { get { return _health; } set { _health = value; } }
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float AttackPoints { get { return _attackPoints; } set { _attackPoints = value; } }
    public float DefensePoints { get { return _defensePoints; } set { _defensePoints = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    #endregion

    #region PUBLIC FUNCTIONS
    public virtual void ActivateSkill1()
    {

    }

    public virtual void ActivateSkill2()
    {

    }

    public virtual void ActivateSkill3()
    {

    }
    #endregion
}
