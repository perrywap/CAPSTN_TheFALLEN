using System.Collections;
using System.Collections.Generic;
//using System.Numerics; // note do not use since it fucks up vector3 and vector2
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scroll : MonoBehaviour
{

    public float scrollSpeed = 20;

    public float removePanelTimer;//add time
    public float removePanelRate;

    public GameObject turnOffPanel;
    public GameObject enablePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float transition = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //this.transform.position += new Vector3(transition, 0, 0);

        //float transition2 = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //this.transform.position += new Vector3(0, transition2, 0);

        Vector3 pos = transform.position;

        UnityEngine.Vector3 localVectorUp = transform.TransformDirection(0, 1, 0);

        pos += localVectorUp * scrollSpeed * Time.deltaTime;
        transform.position = pos;

        //UnityEngine.Vector3 pos = transform.position;
        //transform.position += System.Numerics.Vector3.up * Time.deltaTime;

        //UnityEngine.Vector3 localVectorUp = transform.GetLocalPositionAndRotation(0, 1, 0);

        //pos += localVectorUp * scrollSpeed * Time.deltaTime;
        //transform.position = pos;

        removePanelTimer += 1 * Time.deltaTime;
        // Debug.Log("Time: " + spawnTimer);

        if (removePanelTimer > removePanelRate) //when timer is > rate then the panel is turned off
        {
            removePanelTimer = 0;           
            turnOffPanel.SetActive(false);
            enablePlayer.SetActive(true);
        }
    }

    

}
