using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region VARIABLES
    [SerializeField] private string _mapName;

    #endregion

    #region GETTERS AND SETTERS
    public string MapName {  get { return _mapName; } }
    #endregion
}
