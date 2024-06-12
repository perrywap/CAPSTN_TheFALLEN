using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region GAMESTATE AND SINGLETON
    // SINGLETON
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    [SerializeField] private GameState startingState;
    
    public GameState GameState { get; private set; }

    [Header("Managers")]
    public LevelManager levelManager;
    public PlayerManager playerManager;
    public UIManager uiManager;
    #endregion

    #region UNITY FUNCTIONS
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);    
        }

        // Set up game state
        GameState = Instantiate(startingState);
        levelManager.GameState = GameState;
        playerManager.GameState = GameState;
    }
    #endregion
}
