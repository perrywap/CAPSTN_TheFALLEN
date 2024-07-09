using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Player
{
    [Header("Dash Settings")]
    [SerializeField] private float _dashingSpeed = 25f;
    [SerializeField] private float dashingDuration = 0.2f;
    [SerializeField] private TrailRenderer trailRenderer;
    public bool isDashing;

    [Header("AfterImage Settings")]
    private float lastImageXpos; 
    public float distanceBetweenImages;

    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSkill1()
    {   
        if(this.canUseSkill1 )
        {
            Debug.Log("Hero is using DASH skill");
            StartCoroutine(Dash());
        }   
    }

    public override void ActivateSkill2()
    {
        Debug.Log("Hero is using BLOCK skill");
    }

    public override void ActivateSkill3()
    {
        Debug.Log("Hero is using AURA skill");
    }

    public void ActivateSkill4()
    {
        Debug.Log("Hero is using DIVINE JUDGEMENT skill");
    }
    #endregion

    private IEnumerator Dash()
    {
        isDashing = true;

        //HeroAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.transform.localScale.x * _dashingSpeed, 0f);

        //if(Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
        //{
        //    HeroAfterImagePool.Instance.GetFromPool();
        //    lastImageXpos = transform.position.x;
        //}

        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingDuration);
        trailRenderer.emitting = false;
        isDashing = false;
        StartCoroutine(SupportSkillOnCoolDown());
    }

    private IEnumerator SupportSkillOnCoolDown()
    {
        this.canUseSkill1 = false;
        yield return new WaitForSeconds(this.skill1CD);
        this.canUseSkill1 = true;
    }
}
