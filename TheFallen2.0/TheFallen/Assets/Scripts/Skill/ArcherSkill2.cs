using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkill2 : SkillBase
{
    [SerializeField] private GameObject projectileGO;
    [SerializeField] private Transform projectileSpawnArea;
    [SerializeField] private float projectileForce;
    [SerializeField] private bool startedDrawing;

    private float damage;
    public float drawTimer;

    private void Update()
    {
        CheckCombatInput();
    }

    private void OnBowDraw()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isDrawing", true);

        StartCoroutine(DrawTime());
    }

    private void OnBowRelease()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isDrawing", false);

        StopCoroutine(DrawTime());
        StartCoroutine(SkillOnCoolDown());
        Shoot();
    }

    private void CheckCombatInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnBowDraw();
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            OnBowRelease();
        }
    }

    private void Shoot()
    {
        projectileSpawnArea.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isFacingRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        GameObject newArrow = Instantiate(projectileGO, projectileSpawnArea.position, projectileSpawnArea.rotation);
        Projectile projectile = newArrow.GetComponent<Projectile>();

        if (drawTimer < .15f)
        {
            // LOW DAMAGE
        }
        else
        {
            // HIGH DAMAGE
        }

        newArrow.GetComponent<Rigidbody2D>().velocity = projectileSpawnArea.right * projectileForce;
    }

    public IEnumerator DrawTime()
    {
        for (drawTimer = 0f; drawTimer <= 1f; drawTimer += Time.deltaTime)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("isDrawing") == false)
                break;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
