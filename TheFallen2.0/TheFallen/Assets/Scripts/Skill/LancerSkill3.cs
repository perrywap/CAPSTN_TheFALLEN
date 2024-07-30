using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerSkill3 : SkillBase
{
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject spearPrefab;
    [SerializeField] private GameObject spearGO;
    [SerializeField] private float launchForce;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip skillSound;
    private AudioSource audioSource;

    public bool isShooting;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            ThrowSpear();
            isShooting = false;
        }
    }

    public override void ActivateSkill()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("isThrowingSpear");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

        PlaySkillSound(); // Play the skill sound
        StartCoroutine(ModifyRBVelocity());
    }

    public void ThrowSpear()
    {
        launchPoint.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isFacingRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        spearGO = Instantiate(spearPrefab, launchPoint.position, launchPoint.rotation);
        Spear spear = spearGO.GetComponent<Spear>();
        spearGO.GetComponent<Rigidbody2D>().velocity = launchPoint.right * launchForce;
    }

    private IEnumerator ModifyRBVelocity()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
    }

    private void PlaySkillSound()
    {
        if (audioSource != null && skillSound != null)
        {
            audioSource.PlayOneShot(skillSound);
        }
    }
}
