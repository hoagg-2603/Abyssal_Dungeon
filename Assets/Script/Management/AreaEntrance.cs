using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    [SerializeField] private string transitionName;
    private void Start()
    {
        if (transitionName == ScreenManagement.Instance.SceneTransitionName)
        {
            PlayerController.Instance.transform.position = transform.position;
            CameraController.Instance.SetPlayerCameraFollow();
            UIFade.Instance.FadeToClear();
        }
    }
}

