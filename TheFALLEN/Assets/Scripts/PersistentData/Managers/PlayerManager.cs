using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerManager", menuName =
    "Scripts/PersistentData/Managers/PlayerManager", order = 2)]
public class PlayerManager : ScriptableObject
{
    private GameObject playerPrefab;

    public GameObject ActivePlayer { get; private set; }

    //[SerializeField] private PlayerStats startingPlayerStats;
    //public PlayerStats PlayerStsats {  get; private set; }
    public GameState GameState { get; set; }

    public string spawnTag;

    private void OnEnable()
    {
        LevelEvents.levelLoaded += SpawnPlayer;
        //PlayerStats = Instantiate(startingPlayerStats);
    }
    protected void SpawnPlayer(Transform spawnTransform)
    {
        if (GameState.playerSpawnLocation != "")
        {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag(spawnTag);
            bool foundSpawn = false;

            foreach (GameObject spawn in spawns)
            {
                if(spawn.name == GameState.playerSpawnLocation) 
                {
                    foundSpawn = true;

                    ActivePlayer = Instantiate(playerPrefab, spawn.transform.position, Quaternion.identity);
                    break;
                }
            }
            if (!foundSpawn)
            {
                throw new MissingReferenceException("Could not find the player spawn location" +
                    "with the name " + GameState.playerSpawnLocation);
            }
        } 
        else
        {
            ActivePlayer = Instantiate(playerPrefab, spawnTransform.position, Quaternion.identity);
            Debug.Log("Player spawned at default location: " + spawnTransform);
        }

        if(ActivePlayer)
        {
            //PlayerEvents.onPlayerSpawned.Invoke(ActivePlayer.transform);
        }
        else
        {
            throw new MissingReferenceException("No AcitvePlayer in PlayerManager. May have failed to spawn.");
        }
    }

    void OnDisable()
    {
        LevelEvents.levelLoaded -= SpawnPlayer;
    }
}
