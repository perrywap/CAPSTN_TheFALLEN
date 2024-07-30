using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherCombatController : CombatController
{
    [SerializeField] private GameObject projectileGO;
    [SerializeField] private Transform projectileSpawnArea;
    [SerializeField] private float projectileForce;
    [SerializeField] private bool startedDrawing;
    public float drawTimer;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip bowDrawSound;
    [SerializeField] private AudioClip bowReleaseSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnBowDraw()
    {
        this.GetComponent<Player>().canMove = false;
        this.GetComponent<Player>().isAttacking = true;

        if (combatEnabled)
        {
            anim.SetBool("isDrawing", true);
            PlayBowDrawSound();
        }
        StartCoroutine(DrawTime());
    }

    private void OnBowRelease()
    {
        this.GetComponent<Player>().canMove = true;

        StopCoroutine(DrawTime());
        gotInput = true;
        this.GetComponent<Player>().isAttacking = false;
        anim.SetBool("isDrawing", false);

        PlayBowReleaseSound();
    }

    public override void CheckCombatInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            OnBowDraw();
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            OnBowRelease();
        }
    }

    public override void CheckAttacks()
    {
        if (gotInput)
        {
            if (!this.GetComponent<Player>().isAttacking)
            {
                Shoot();
                drawTimer = 0;

                gotInput = false;
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", this.GetComponent<Player>().isAttacking);

                anim.SetBool("attack1", true);

                isFirstAttack = true;
            }
        }
    }

    private void Shoot()
    {
        projectileSpawnArea.rotation = this.GetComponent<Player>().isFacingRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        GameObject newArrow = Instantiate(projectileGO, projectileSpawnArea.position, projectileSpawnArea.rotation);
        Projectile projectile = newArrow.GetComponent<Projectile>();

        if (drawTimer < .15f)
            newArrow.GetComponent<Rigidbody2D>().velocity = projectileSpawnArea.right * 10f;
        else
            newArrow.GetComponent<Rigidbody2D>().velocity = projectileSpawnArea.right * projectileForce;
    }

    public IEnumerator DrawTime()
    {
        for (drawTimer = 0f; drawTimer <= 1f; drawTimer += Time.deltaTime)
        {
            if (anim.GetBool("isDrawing") == false)
                break;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private void PlayBowDrawSound()
    {
        if (audioSource != null && bowDrawSound != null)
        {
            audioSource.PlayOneShot(bowDrawSound);
        }
    }

    private void PlayBowReleaseSound()
    {
        if (audioSource != null && bowReleaseSound != null)
        {
            audioSource.PlayOneShot(bowReleaseSound);
        }
    }
}
