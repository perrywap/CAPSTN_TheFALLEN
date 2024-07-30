using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkill1 : SkillBase
{
    [Header("Dash Settings")]
    [SerializeField] private float _dashingSpeed = 25f;
    [SerializeField] private float dashingDuration = 0.2f;
    [SerializeField] private TrailRenderer trailRenderer;
    public bool isDashing;

    private void Start()
    {
        trailRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<TrailRenderer>();
    }

    public override void ActivateSkill()
    {
        if (canUseSkill)
        {
            Debug.Log("Hero is using DASH skill");
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.localScale.x * _dashingSpeed, 0f);

        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingDuration);
        trailRenderer.emitting = false;
        isDashing = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;

        StartCoroutine(SkillOnCoolDown());
    }
}
