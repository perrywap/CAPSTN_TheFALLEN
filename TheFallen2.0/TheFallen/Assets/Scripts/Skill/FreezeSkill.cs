using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSkill : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DisposeGO());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private IEnumerator DisposeGO()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
