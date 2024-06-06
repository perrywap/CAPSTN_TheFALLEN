using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager", menuName = 
    "Scripts/PersistentData/Managers/LevelManager", order = 1)]

public class LevelManager : ScriptableObject
{
    public GameState GameState { get; set; }

    private void OnEnable()
    {
        LevelEvents.levelExit += OnLevelExit;
    }

    private void OnLevelExit(SceneAsset nextLevel, string playerSpawnTrasformName)
    {
        GameState.playerSpawnLocation = playerSpawnTrasformName;
        SceneManager.LoadScene(nextLevel.name, LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        LevelEvents.levelExit -= OnLevelExit;
    }
}
 