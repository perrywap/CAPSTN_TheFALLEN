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
    [SerializeField] private AudioClip[] switchAudioClips;
    private AudioSource audioSource;

    public static CharacterSwitchManager Instance { get; private set; }
    #endregion

    #region UNITY FUNCTIONS
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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
        if (playerGO.GetComponent<Player>().isGrounded && !playerGO.GetComponent<Player>().isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Switched to HERO");
                PlaySwitchSound(0);
                SwitchCharacter(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Switched to LANCER");
                PlaySwitchSound(1);
                SwitchCharacter(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Debug.Log("Switched to ARCHER");
                PlaySwitchSound(2);
                SwitchCharacter(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.Log("Switched to WIZARD");
                PlaySwitchSound(3);
                SwitchCharacter(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Debug.Log("Switched to SAINT");
                PlaySwitchSound(4);
                SwitchCharacter(4);
            }
        }
    }

    private void PlaySwitchSound(int index)
    {
        // Play the audio clip for the corresponding character switch
        if (audioSource != null && switchAudioClips.Length > index && switchAudioClips[index] != null)
        {
            audioSource.clip = switchAudioClips[index];
            audioSource.Play();
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

        if (localscale.x < 0)
        {
            playerGO.GetComponent<Player>().isFacingRight = false;
        }
        playerGO.transform.localScale = localscale;

        Player player = playerGO.GetComponent<Player>();
    }
    #endregion
}
