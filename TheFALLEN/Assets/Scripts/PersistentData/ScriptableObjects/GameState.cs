using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameState", menuName = "Scripts/PersistentData/ScriptableObjects/GameState", order = 3)]

public class GameState : ScriptableObject
{
    public string playerSpawnLocation = "";
}
