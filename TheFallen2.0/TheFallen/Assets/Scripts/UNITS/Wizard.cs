using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player
{
    [SerializeField] private float SupportSkillNextTime;
    [SerializeField] private float SupportSkillActiveTime;
    [SerializeField] private float SupportSkillOffTime;

    [SerializeField] private float HeavySkillNextTime;

    [SerializeField] private GameObject explosionBullet;
    [SerializeField] Transform Spawn;

    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSkill1()
    {
        Debug.Log("Wizard is using FLOAT skill");
        if (Time.time - SupportSkillNextTime < this.GetComponent<Player>().skill1CD)
        {
            return;
        }
        SupportSkillNextTime = Time.time;

        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        if (Time.time - SupportSkillActiveTime < SupportSkillOffTime)
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public override void ActivateSkill2()
    {
        Debug.Log("Wizard is using FREEZE skill");
    }

    public override void ActivateSkill3()
    {
        Debug.Log("Wizard is using FLAME skill");
        if (Time.time - HeavySkillNextTime < this.GetComponent<Player>().skill3CD)
        {
            return;
        }
        HeavySkillNextTime = Time.time;

        //gagawa ng red ball bullet na sprite and the explosion radius na malaki na sprite bale 2 game objects sila na will spawn the bullet will spawn from wizard's shot spawn, tapos yung radius on hit ng bullet will spawn ontop of saan naghit
        Instantiate(explosionBullet, Spawn.position, transform.rotation);
    }
    #endregion
}
