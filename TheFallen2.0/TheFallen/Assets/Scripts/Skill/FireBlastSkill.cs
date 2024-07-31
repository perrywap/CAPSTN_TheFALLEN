using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlastSkill : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private Animator anim;
    public bool hasFinishedCasting;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Dispose());
    }

    private void Update()
    {
        if (hasFinishedCasting)
            anim.SetTrigger("Shoot");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)
        {
            anim.SetTrigger("Hit");
            GameObject exposionGO = Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            StartCoroutine(DelayedDispose());
        }
    }

    private IEnumerator Dispose()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private IEnumerator DelayedDispose()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }
}
