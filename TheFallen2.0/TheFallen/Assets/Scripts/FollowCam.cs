using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject followCam;


    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;
    public Vector3 positionOffset;

    [Header("Axis Limitation")]
    public Vector2 xLimit;
    public Vector2 yLimit;

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 targetPosition = player.transform.position + positionOffset;

        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);

        followCam.transform.position = Vector3.SmoothDamp(followCam.transform.position, targetPosition, ref velocity, smoothTime);
    }
}
