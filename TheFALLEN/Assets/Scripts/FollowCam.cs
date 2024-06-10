using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _followCam;


    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;
    public Vector3 positionOffset;

    [Header("Axis Limitation")]
    public Vector2 xLimit;
    public Vector2 yLimit;

    private void Update()
    {
        if (CharacterSwitchManager.Instance.PlayerGO != null)
        {
            _player = CharacterSwitchManager.Instance.PlayerGO;

            Vector3 targetPosition = _player.transform.position + positionOffset;
            targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);

            _followCam.transform.position = Vector3.SmoothDamp(_followCam.transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
            return;
    }
}
