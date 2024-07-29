using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSwitchManager : MonoBehaviour 
{
    #region VARIABLES
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private GameObject playerGO;

    [SerializeField] private Transform switchLocation;
    [SerializeField] private float switchCooldown;

    private int lastCharacterIndex = 0;

    public bool[] canSwitch = new bool[5];
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
        canSwitch[0] = true;
        canSwitch[1] = true;
        canSwitch[2] = true;
        canSwitch[3] = true;
        canSwitch[4] = true;
    }
    private void Update()
    {
        CheckSwitch();
        CooldownIcon();
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
        if (playerGO.GetComponent<Player>().isGrounded && !playerGO.GetComponent<Player>().isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (playerGO.GetComponent<Player>().character == Character.HERO)
                    return;

                if (canSwitch[0])
                {
                    StartCoroutine(StartSwitchCooldown(lastCharacterIndex));
                    SwitchCharacter(0);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (playerGO.GetComponent<Player>().character == Character.LANCER)
                    return;

                if (canSwitch[1])
                {
                    StartCoroutine(StartSwitchCooldown(lastCharacterIndex));
                    SwitchCharacter(1);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (playerGO.GetComponent<Player>().character == Character.ARCHER)
                    return;

                if (canSwitch[2])
                {
                    StartCoroutine(StartSwitchCooldown(lastCharacterIndex));
                    SwitchCharacter(2);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (playerGO.GetComponent<Player>().character == Character.WIZARD)
                    return;

                if (canSwitch[3])
                {
                    StartCoroutine(StartSwitchCooldown(lastCharacterIndex));
                    SwitchCharacter(3);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (playerGO.GetComponent<Player>().character == Character.SAINT)
                    return;

                if (canSwitch[4])
                {
                    StartCoroutine(StartSwitchCooldown(lastCharacterIndex));
                    SwitchCharacter(4);
                }
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
        HudManager.Instance.UpdateSkillIcons(index, playerGO);

        lastCharacterIndex = index;
    }
    #endregion

    private void CooldownIcon()
    {
        for (int i = 0; i < canSwitch.Length; i++)
        {
            if (!canSwitch[i])
                HudManager.Instance.iconImages[i].fillAmount += Time.deltaTime / switchCooldown;
        }
    }

    private IEnumerator StartSwitchCooldown(int index)
    {
        HudManager.Instance.iconImages[index].fillAmount = 0 / switchCooldown;
        canSwitch[index] = false;
        yield return new WaitForSecondsRealtime(switchCooldown);
        canSwitch[index] = true;
    }
}
