using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Archer : Player
{
    [Header("Support Skill")]
    [SerializeField] private float SupportSkillCoolDownTime;
    [SerializeField] private float SupportSkillNextTime;

    [Header("Light Skill")]
    [SerializeField] private float LightSkillCoolDownTime;
    [SerializeField] private float LightSkillNextTime;

    [Header("Heavy Skill")]
    [SerializeField] private float HeavySkillCoolDownTime;
    [SerializeField] private float HeavySkillNextTime;

    [Header("Ultimate Skill")]
    [SerializeField] private float UltimateSkillCoolDownTime;
    [SerializeField] private float UltimateSkillNextTime;

    [SerializeField] bool isAttacking = false;

    [SerializeField] private GameObject chargedProjectile;
    [SerializeField] private float chargeSpeed;
    [SerializeField] private float chargeTime;
    private bool isCharging;

    //private bool isFacingRight = true;
    //private float input;

    #region OVERRIDABLE FUNCTIONS

    //public float arrowSpeed;

    public GameObject arrowPrefab;
    //public Transform parent;
    //public Vector3 newPosition;
    //public quaternion newRotation;

    public Vector3 moveDirection;

    private void Update()
    {
        //====

        //float transition = Input.GetAxis("Horizontal") * arrowSpeed * Time.deltaTime;
        //this.transform.position += new Vector3(transition, 0, 0);

        //float transition2 = Input.GetAxis("Vertical") * arrowSpeed * Time.deltaTime;
        //this.transform.position += new Vector3(0, transition2, 0);

        //this.newPosition += new Vector3(3, 0, 0);

        //===

        //input = Input.GetAxisRaw("Horizontal");

        //if(input > 0 && isFacingRight == false)
        //{
        //    flip();
        //}
        //else if(input < 0 && isFacingRight == true)
        //{
        //    flip();
        //}

        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(arrowPrefab, this.transform.position, Quaternion.identity);
            //Instantiate(arrowPrefab, newPosition, newRotation, parent);

            chargeTime = 0;

            Debug.Log("fire arrow!");
        }

        if (chargeTime < 2)
        {
            isCharging = true;
            if (isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed;
            }
        }
        if (chargeTime >= 2)
        {
            ActivateLightSkill();
        }

    }
    //void flip()
    //{
    //    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    //    //transform.Rotate(0f, 180f, 0f);
    //    isFacingRight = !isFacingRight;

    //}
    public override void ActivateSupportSkill()
    {
        if (Time.time - SupportSkillNextTime < SupportSkillCoolDownTime)
        {
            return;
        }
        SupportSkillNextTime = Time.time;

        transform.position = new Vector2(transform.position.x -5, transform.position.y);
        this.GetComponent<Player>().IsUsingSkill = true; //setter
        Debug.Log("Archer is using TUMBLE skill");

        bool isArcherAttacking = this.GetComponent<Player>().IsAttacking; //getter, getting the value of IsAttacking

        Instantiate(arrowPrefab, this.transform.position, Quaternion.identity);

        StartCoroutine(waitingSkill(0.5f));

        //bool isArcherAttacking = this.GetComponent<Player>() != null;

        //Instantiate(arrowPrefab, this.transform.position, Quaternion.identity);
    }

    public override void ActivateLightSkill()
    {
        Debug.Log("Archer is using CHARGED SHOT skill");


       // Instantiate(arrowPrefab, this.transform.position, Quaternion.identity);
        isCharging = false;
        chargeTime = 0;
    }

    public override void ActivateHeavySkill()
    {
        Debug.Log("Archer is using MAKE IT RAIN skill");
    }

    public override void ActivateUltimateSkill()
    {
        Debug.Log("Archer is using WIND RUNNER skill");
    }

    IEnumerator waitingSkill(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    #endregion
}
