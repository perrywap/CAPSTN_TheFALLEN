using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    #region VARIABLES
    [Header("Character Stats")]
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    [Header("Booleans")]
    public bool isFacingRight = true;
    public bool isWalking;
    public bool isGrounded;
    public bool isAttacking;
    public bool canJump;
    public bool canMove;
    public bool isUsingSkill;

    private Animator anim;

    [Header("Unit Status")]
    public bool isDead = false;
    #endregion

    #region GETTERS AND SETTERS
    public float Health { get { return _health; } set { _health = value; } }
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    #endregion

    #region UNITY FUNCTIONS
    private void Start()
    {
        canMove = true;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        anim.SetTrigger("damaged");
        _health -= damageAmount;
        if(_health <= 0 )
        {
            _health = 0;
            Die();
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }
    #endregion
}
