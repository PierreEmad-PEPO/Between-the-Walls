using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineCamera fpCamera;
    [SerializeField] private PlayerMovement playerMovement;

    public static CameraManager Instance;

    CinemachineCamera activeCamera;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    

    public void SwitchCamera(CinemachineCamera camera)
    {
        fpCamera.Priority = 0;
        camera.Priority = 1;
        playerMovement.enabled = false;
        activeCamera = camera;
    }

    public void SwitchToMain()
    {
        fpCamera.Priority = 1;
        playerMovement.enabled = true;

        if (activeCamera != null)
            activeCamera.Priority = 0;
    }
}
