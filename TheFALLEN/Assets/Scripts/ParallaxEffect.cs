using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;

    // Starting position for the parallax game object
    private Vector2 _startingPosition;

    // Start Z value of the parallax game object
    private float _startingZ;

    private Vector2 camMoveSinceStart => (Vector2)_camera.transform.position - _startingPosition;
    private float zDistanceFromTarget => transform.position.z - _target.transform.position.z;
    float clippingPlane => (_camera.transform.position.z + (zDistanceFromTarget > 0 ? _camera.farClipPlane : _camera.nearClipPlane));
    private float parallaxFactor => Mathf.Abs(zDistanceFromTarget / clippingPlane);
    #endregion

    #region UNITY FUNCTIONS
    private void Start()
    {
        if (CharacterSwitchManager.Instance.PlayerGO != null)
        {
            _target = CharacterSwitchManager.Instance.PlayerGO.transform;

            _startingPosition = transform.position;
            _startingZ = transform.position.z;
        }
        else 
            return;
    }

    private void Update()
    {
        Vector2 newPosition = _startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, _startingZ);
    }
    #endregion
}
