using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBase : MonoBehaviour
{
    public Sprite skillImage;
    public float skillCooldown;
    public bool canUseSkill;

    private void FixedUpdate()
    {
        
    }

    private void CheckCooldown()
    {
       
    }

    public virtual void ActivateSkill()
    {

    }

    public IEnumerator SkillOnCoolDown()
    {
        this.canUseSkill = false;
        yield return new WaitForSeconds(skillCooldown);
        this.canUseSkill = true;
    }
}
