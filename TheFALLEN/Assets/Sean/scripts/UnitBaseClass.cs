using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitBaseClass : MonoBehaviour
{

    [SerializeField] private float HP = 10;
    [SerializeField] private float attack;
    [SerializeField] private float defense;
    [SerializeField] private float attackSpeed;

    public float speed;//note I made this speed variable so I can test collision for the scene switching at the start and end of each level

    void Update()
    {

        float transition = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        this.transform.position += new Vector3(transition, 0, 0);

        float transition2 = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        this.transform.position += new Vector3(0, transition2, 0);       
        
    }
}
