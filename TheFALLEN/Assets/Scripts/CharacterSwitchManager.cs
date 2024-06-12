using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitchManager : Singleton<CharacterSwitchManager>
{
    #region VARIABLES
    [SerializeField] private GameObject[] _playerPrefabs;
    [SerializeField] private Transform _playerParent;
    [SerializeField] private GameObject _playerGO;

    private Transform swapLocation;
    public GameObject PlayerGO {  get { return _playerGO; } }
    #endregion

    #region UNITY FUNCTIONS
    private void Update()
    {
        if (_playerGO == null)
        {
            swapLocation = _playerParent;
            ChangeCharacter(0);
        }
    }

    private void LateUpdate()
    {
        swapLocation = _playerGO.transform;
    }
    #endregion

    #region FUNCTIONS
    public void ChangeCharacter(int index)
    {
        if (_playerGO != null) 
        {
            swapLocation = _playerGO.transform;
            Destroy(_playerGO);
        }

        _playerGO = Instantiate(_playerPrefabs[index], swapLocation.position, Quaternion.identity);
        _playerGO.transform.parent = _playerParent;
        Player player = _playerGO.GetComponent<Player>();
    }
    #endregion
}
