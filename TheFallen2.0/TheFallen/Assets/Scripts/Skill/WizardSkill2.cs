using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardSkill2 : SkillBase
{
    [SerializeField] private ParticleSystem freezeParticle;
    [SerializeField] private AudioClip skillSoundClip; 
    private AudioSource skillSoundSource; 

    private void Start()
    {
        
        skillSoundSource = gameObject.AddComponent<AudioSource>();
        skillSoundSource.clip = skillSoundClip;
        skillSoundSource.spatialBlend = 0; 
        skillSoundSource.dopplerLevel = 0; 
    }

    public override void ActivateSkill()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isUsingSkill = true;

        freezeParticle.Play();

        
        if (skillSoundSource != null && skillSoundClip != null)
        {
            skillSoundSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            Debug.Log("Is colliding");
            enemy.transform.SendMessage("Damage", 0f);
        }
    }
}
