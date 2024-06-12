using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public Transform defaultPlayerSpawn;

    private void Start()
    {
        LevelEvents.levelLoaded.Invoke(defaultPlayerSpawn); 
    }
}
