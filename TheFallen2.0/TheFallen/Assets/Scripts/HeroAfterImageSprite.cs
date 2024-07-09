using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAfterImageSprite : MonoBehaviour
{
    [SerializeField] private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField] private float alphaSet;
    [SerializeField] private float alphaMultiplier = 0.85f;

    private Transform hero;

    private SpriteRenderer sr;
    private SpriteRenderer heroSR;

    private Color color;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        hero = GameObject.FindGameObjectWithTag("Hero").transform;
        heroSR = hero.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        sr.sprite = heroSR.sprite;
        transform.position = hero.position;
        transform.localScale = hero.localScale;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f, 1f, 1f, alpha);
        sr.color = color;

        if(Time.time >= (timeActivated + activeTime))
        {
            HeroAfterImagePool.Instance.AddToPool(gameObject);  
        }
    }
}
