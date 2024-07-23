using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkill4 : SkillBase
{
    [SerializeField] private GameObject ultSwordPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform landingPosition;

    private GameObject swordGO;

    private void Update()
    {
        if (swordGO == null)
            return;

        if (swordGO.transform.position.y < landingPosition.position.y)
        {
            Debug.Log("Should stop");
            swordGO.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    public override void ActivateSkill()
    {
        StartCoroutine(ModifyRBVelocity());

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("isUsingUlt");


        swordGO = Instantiate(ultSwordPrefab, spawnPosition.position, Quaternion.identity);
        UltSword ultSword = swordGO.GetComponent<UltSword>();

        // SOUND LOGIC
        swordGO.GetComponent<Rigidbody2D>().velocity = -spawnPosition.up * 200f;      
    }

    private IEnumerator ModifyRBVelocity()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = false;
    }
}
