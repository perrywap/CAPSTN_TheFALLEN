using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSwitchManager : MonoBehaviour 
{
    #region VARIABLES
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private GameObject playerGO;

    [SerializeField] private Transform switchLocation;
   
    public static CharacterSwitchManager Instance { get; private set; }
    #endregion

    #region UNITY FUNCTIONS
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SwitchCharacter(0);
    }
    private void Update()
    {
        CheckSwitch();
    }
    private void LateUpdate()
    {
        if (playerGO == null)
            return;
        else
            switchLocation = playerGO.transform;
    }
    #endregion

    #region PRIVATE METHODS
    private void CheckSwitch()
    {
        //if(playerGO.GetComponent<Player>().isGrounded && !playerGO.GetComponent<CombatController>().isAttacking)
        if (playerGO.GetComponent<Player>().isGrounded && !playerGO.GetComponent<Player>().isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //call Hero Swap function
                Debug.Log("Switched to HERO");
                SwitchCharacter(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //call Lancer Swap function
                Debug.Log("Switched to LANCER");
                SwitchCharacter(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //call Archer Swap function
                Debug.Log("Switched to ARCHER");
                SwitchCharacter(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                //call Wizard Swap function
                Debug.Log("Switched to WIZARD");
                SwitchCharacter(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                //call Saint Swap function
                Debug.Log("Switched to SAINT");
                SwitchCharacter(4);
            }
        }
    }

    private void SwitchCharacter(int index)
    {
        Vector3 localscale = Vector3.one;

        if (playerGO != null)
        {
            switchLocation = playerGO.transform;
            localscale = playerGO.transform.localScale;
            Destroy(playerGO);
        }

        playerGO = Instantiate(playerPrefabs[index], switchLocation.position, Quaternion.identity);
        
        if(localscale.x < 0)
        {
            playerGO.GetComponent<Player>().isFacingRight = false;
        }
        playerGO.transform.localScale = localscale;
        
        Player player = playerGO.GetComponent<Player>();
    }
    #endregion
}
