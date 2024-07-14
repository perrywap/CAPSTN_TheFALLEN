using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Player
{
    [Header("Dash Skill")]
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime;

    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Hero is using DASH skill");
        StartCoroutine(Dash());
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
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();

        this.CanUseSupportSkill = false;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(this.gameObject.transform.localScale.x * dashingPower, 0f);
        Debug.Log(rb.velocity);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        this.CanUseSupportSkill = true;
    }
}