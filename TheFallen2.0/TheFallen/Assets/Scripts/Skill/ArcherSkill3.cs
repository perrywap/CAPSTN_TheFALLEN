using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkill3 : SkillBase
{
    [SerializeField] private Transform spawnArea;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float projectileForce;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip shootSound;
    private AudioSource audioSource;

    public bool shootArrows;

    private void Start()
    {
        // Assuming the AudioSource is on the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (shootArrows)
        {
            StartCoroutine(RainArrow());
            shootArrows = false;
        }
    }

    public override void ActivateSkill()
    {
        StartCoroutine(ModifyRBVelocity());
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("shootArrows");
        PlayShootSound();  // Play sound effect only once when the skill is activated
    }

    private void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, new Vector3(spawnArea.position.x + Random.Range(-5f, 5f), spawnArea.position.y, 0), Quaternion.Euler(0, 0, -90));
        Projectile projectile = arrow.GetComponent<Projectile>();

        arrow.GetComponent<Rigidbody2D>().velocity = -spawnArea.up * projectileForce;
    }

    private void PlayShootSound()
    {
        if (audioSource && shootSound)
        {
            Debug.Log("Playing shoot sound");
            audioSource.PlayOneShot(shootSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or shootSound is missing");
        }
    }

    private IEnumerator RainArrow()
    {
        InvokeRepeating("Shoot", 0.2f, 0.01f);
        yield return new WaitForSecondsRealtime(1f);
        CancelInvoke("Shoot");
    }

    private IEnumerator ModifyRBVelocity()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;
        yield return new WaitForSeconds(1.2f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
    }
}
