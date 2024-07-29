using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerSkill2 : SkillBase
{
    [Header("Skill Settings")]
    public float damage;
    public float ravageSpearDuration = 2f;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip skillSound;  // Assign your AudioClip in the inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public override void ActivateSkill()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlaySkillSound();  // Play sound effect when the skill is activated
        StartCoroutine(RavageSpear());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("isRavagingSpear"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.transform.SendMessage("Damage", damage);
            }
        }
    }

    private IEnumerator RavageSpear()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isRavagingSpear", true);

        yield return new WaitForSeconds(ravageSpearDuration);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isRavagingSpear", false);
    }

    private void PlaySkillSound()
    {
        if (audioSource && skillSound)
        {
            Debug.Log("Playing skill sound");
            audioSource.PlayOneShot(skillSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or skillSound is missing");
        }
    }
}
