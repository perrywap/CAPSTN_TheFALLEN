using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkill1 : SkillBase
{
    [Header("Dash Settings")]
    [SerializeField] private float _dashingSpeed = 25f;
    [SerializeField] private float dashingDuration = 0.2f;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private AudioClip dashSound;
    private AudioSource audioSource;

    public bool isDashing;

    private void FixedUpdate()
    {
        trailRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<TrailRenderer>();
        audioSource = GameObject.FindGameObjectWithTag("Player").AddComponent<AudioSource>();
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

        // Play dash sound
        if (dashSound != null)
        {
            audioSource.PlayOneShot(dashSound);
        }

        yield return new WaitForSeconds(dashingDuration);

        trailRenderer.emitting = false;
        isDashing = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;

        StartCoroutine(SkillOnCoolDown());
    }
}
