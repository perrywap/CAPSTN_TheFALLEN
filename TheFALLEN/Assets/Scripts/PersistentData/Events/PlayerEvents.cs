using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents
{
    public static UnityAction<Transform> onPlayerSpawned;
    public static UnityAction<Vector3> onPlayerMove;

    public static UnityAction onPlayerDespawned;

}
