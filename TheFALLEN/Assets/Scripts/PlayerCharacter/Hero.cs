using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : Player
{
    [Header("Dash Settings")]
    [SerializeField] private float _dashingSpeed = 25f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private float dashingDuration = 0.5f;
    private bool _isDashing;

    public bool IsDashing { get { return _isDashing; } set {  _isDashing = value; } }


    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Hero is using DASH skill");
        if(this.CanUseSupportSkill)
        {
            StartCoroutine(Dash());
        }
    }

    public override void ActivateLightSkill()
    {
        Debug.Log("Hero is using BLOCK skill");
    }

    public override void ActivateHeavySkill()
    {
        Debug.Log("Hero is using AURA skill");
    }

    public override void ActivateUltimateSkill()
    {
        Debug.Log("Hero is using DIVINE JUDGEMENT skill");
    }
    #endregion

    private IEnumerator Dash()
    {
        Debug.Log("Should dash");
        _isDashing = true;
        this.GetComponent<PlayerController>().Rb2D.velocity = new Vector2(this.transform.localScale.x * _dashingSpeed, 0f);
        yield return new WaitForSeconds(dashingDuration);
        _isDashing = false;
        StartCoroutine(SupportSkillOnCoolDown());
    }

    private IEnumerator SupportSkillOnCoolDown()
    {
        this.CanUseSupportSkill = false;
        yield return new WaitForSeconds(this.SupportSkillCooldown);
        this.CanUseSupportSkill = true;
    }
}