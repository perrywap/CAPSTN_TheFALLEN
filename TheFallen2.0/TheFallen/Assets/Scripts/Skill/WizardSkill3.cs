using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSkill3 : SkillBase
{

    [SerializeField] private GameObject fireBlastPrefab;
    [SerializeField] private Transform fireBlastCastPoint;
    [SerializeField] private float fireForce;
    public bool castFireBlast;

    private GameObject fireBlastGO;

    private void FixedUpdate()
    {
        if(castFireBlast)
        {
            ShootFireBlast();
            castFireBlast = false;
        }
    }

    public override void ActivateSkill()
    {
        if (canUseSkill && GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isGrounded)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("fireBlast");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;
            StartCoroutine(ModifyRBVelocity());
        }
    }

    private void ShootFireBlast()
    {
        fireBlastCastPoint.rotation = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isFacingRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
        fireBlastGO = Instantiate(fireBlastPrefab, fireBlastCastPoint.position, fireBlastCastPoint.rotation);
        FireBlastSkill fireBlast = fireBlastGO.GetComponent<FireBlastSkill>();
        fireBlastGO.GetComponent<Rigidbody2D>().velocity = fireBlastCastPoint.right * fireForce;
    }

    private IEnumerator ModifyRBVelocity()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(.9f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
        StartCoroutine(SkillOnCoolDown());
    }
}
