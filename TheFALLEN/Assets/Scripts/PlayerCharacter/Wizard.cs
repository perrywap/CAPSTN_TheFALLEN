using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player
{
    [SerializeField] private float SupportSkillCoolDownTime;
    [SerializeField] private float SupportSkillNextTime;
    [SerializeField] private float SupportSkillActiveTime;
    [SerializeField] private float SupportSkillOffTime;
    [SerializeField] private float HeavySkillCoolDownTime;
    [SerializeField] private float HeavySkillNextTime;

    [SerializeField] private Explosion_Bullet explosionBullet;
    [SerializeField] Transform Spawn;

    #region OVERRIDABLE FUNCTIONS
    public override void ActivateSupportSkill()
    {
        Debug.Log("Wizard is using FLOAT skill");
        if (Time.time - SupportSkillNextTime < SupportSkillCoolDownTime)
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

    public override void ActivateLightSkill()
    {
        Debug.Log("Wizard is using FREEZE skill");
    }

    public override void ActivateHeavySkill()
    {
        Debug.Log("Wizard is using FLAME skill");
        if (Time.time - HeavySkillNextTime < HeavySkillCoolDownTime)
        {
            return;
        }
        HeavySkillNextTime = Time.time;

        //gagawa ng red ball bullet na sprite and the explosion radius na malaki na sprite bale 2 game objects sila na will spawn the bullet will spawn from wizard's shot spawn, tapos yung radius on hit ng bullet will spawn ontop of saan naghit
        Instantiate(explosionBullet, Spawn.position, transform.rotation);
    }

    public override void ActivateUltimateSkill()
    {
        Debug.Log("Wizard is using BLACK HOLE skill");
    }
    #endregion
}
