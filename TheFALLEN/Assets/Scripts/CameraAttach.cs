using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class CameraAttach : MonoBehaviour
{
    ICinemachineCamera vCam;
    UnityAction<Transform> setCameraTargetAction;

    private void Awake()
    {
        vCam = GetComponent<ICinemachineCamera>();

        setCameraTargetAction = new UnityAction<Transform>(SetCameraTarget);
    }

    void SetCameraTarget(Transform cameraTarget)
    {   
        vCam.Follow = cameraTarget;
        vCam.VirtualCameraGameObject.transform.parent = cameraTarget;
    }

    private void OnEnable()
    {
        PlayerEvents.onPlayerSpawned += setCameraTargetAction;
    }

    private void OnDisable()
    {
        PlayerEvents.onPlayerSpawned -= setCameraTargetAction;
    }
}
