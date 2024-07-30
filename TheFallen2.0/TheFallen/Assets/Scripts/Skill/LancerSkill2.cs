using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerSkill2 : SkillBase
{
    public float damage;
    public float ravageSpearDuration = 2f;

    public override void ActivateSkill()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StartCoroutine(RavageSpear());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("isRavagingSpear"))
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
}
