using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float arrowSpeed = 3;

    [SerializeField] private float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(arrowSpeed, 0, 0) * Time.deltaTime;
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit!");
        //if (collision.gameObject.CompareTag("Enemy"))//look over the tag to determine which enemy is hit
        //{
            
        //    Destroy(this.gameObject);//if bullet hit the enemy sprite, bullet will be destroyed.
        //    Debug.Log("enemy hit!");
        //}
        if (collision.gameObject.CompareTag("OneWayPlatform"))//look over the tag to determine which enemy is hit
        {
            Destroy(this.gameObject);//if bullet hit the enemy sprite, bullet will be destroyed.
            Debug.Log("wall hit!");
        }
    }
}
