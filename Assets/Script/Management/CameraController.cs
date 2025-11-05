using UnityEngine;
using Unity.Cinemachine; 

public class CameraController : Singleton<CameraController>
{
    private CinemachineCamera cineCam;

    public void SetPlayerCameraFollow()
    {
        cineCam = FindFirstObjectByType<CinemachineCamera>();
        cineCam.Follow = PlayerController.Instance.transform;
    }
}
