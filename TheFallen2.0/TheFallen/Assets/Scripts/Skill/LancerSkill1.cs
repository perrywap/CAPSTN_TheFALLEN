using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerSkill1 : SkillBase
{
    [Header("Fall Impact Refs")]
    [SerializeField] private GameObject fallLocationGO;
    private GameObject fallLocation;
    [SerializeField] private GameObject fallImpactPrefab;

    [Header("High Jump Settings")]
    [SerializeField] private bool isHighJumping;
    [SerializeField] private float launchTimer;
    [SerializeField] private float launchSpeed;
    [SerializeField] private float airMoveDuration;
    [SerializeField] private float dropSpeed;
    [SerializeField] private float airMoveSpeed;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip skillActivationSound;
    [SerializeField] private AudioClip landingImpactSound;
    private AudioSource audioSource;

    private float movementInputDirection;
    public bool isLanding;
    public bool launchEnded;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AirMoveInput();

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded && isLanding)
        {
            Instantiate(fallImpactPrefab, this.transform.position, Quaternion.identity);
            PlayLandingImpactSound();
            isLanding = false;
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    public override void ActivateSkill()
    {
        if (canUseSkill && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

            SpawnFallLocationGO();
            PlaySkillActivationSound();

            StartCoroutine(launching());
        }
    }

    private void SpawnFallLocationGO()
    {
        fallLocation = Instantiate(fallLocationGO, this.transform.position, Quaternion.identity);
        fallLocation.SetActive(false);
    }

    private void AirMoveInput()
    {
        if (isHighJumping)
        {
            movementInputDirection = Input.GetAxisRaw("Horizontal");
        }
    }

    private void ApplyMovement()
    {
        if (isHighJumping)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(movementInputDirection * airMoveSpeed, 0f);
        }
    }

    private IEnumerator launching()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("launching");
        yield return new WaitForSeconds(launchTimer);
        StartCoroutine(launch());
    }

    private IEnumerator launch()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("highJump");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("highJumpActive", true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0,
             GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y + launchSpeed);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        yield return new WaitForSeconds(.5f);

        StartCoroutine(AirMove());
    }

    private IEnumerator AirMove()
    {
        fallLocation.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(movementInputDirection * airMoveSpeed, 0f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isAirMoving", true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        isHighJumping = true;

        yield return new WaitForSecondsRealtime(airMoveDuration);
        Fall();
    }

    private void Fall()
    {
        isHighJumping = false;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isAirMoving", false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0,
             GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y - dropSpeed);

        StartCoroutine(FallImpact());
    }

    private IEnumerator FallImpact()
    {
        isLanding = true;

        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("highJumpActive", false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        StartCoroutine(SkillOnCoolDown());
    }

    private void PlaySkillActivationSound()
    {
        if (audioSource != null && skillActivationSound != null)
        {
            audioSource.PlayOneShot(skillActivationSound);
        }
    }

    private void PlayLandingImpactSound()
    {
        if (audioSource != null && landingImpactSound != null)
        {
            audioSource.PlayOneShot(landingImpactSound);
        }
    }
}
