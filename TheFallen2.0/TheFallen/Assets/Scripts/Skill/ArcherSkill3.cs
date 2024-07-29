using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkill3 : SkillBase
{
    [SerializeField] private Transform spawnArea;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float projectileForce;
    [SerializeField] private float radius;
    [SerializeField] private float delayTime;
    [SerializeField] private float repeatRate;

    public bool shootArrows;

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
    }

    private void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, new Vector3(spawnArea.position.x + Random.Range(-radius, radius), spawnArea.position.y, 0), Quaternion.Euler(0, 0, -90));
        Projectile projectile = arrow.GetComponent<Projectile>();

        arrow.GetComponent<Rigidbody2D>().velocity = -spawnArea.up * projectileForce;
    }

    private IEnumerator RainArrow()
    {
        InvokeRepeating("Shoot", delayTime, repeatRate);
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
