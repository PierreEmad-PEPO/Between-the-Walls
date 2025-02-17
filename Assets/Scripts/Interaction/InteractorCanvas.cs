using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractorCanvas : MonoBehaviour
{
    [SerializeField] protected GameObject canvas;
    [SerializeField] protected TextMeshProUGUI canvasText;
    [SerializeField] protected Image image;
    private Transform playerCamera;

    public static InteractorCanvas Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        playerCamera = FindAnyObjectByType<PlayerCamera>().transform;
        CloseCanvas();
    }

    private void OnEnable()
        => playerCamera = FindAnyObjectByType<PlayerCamera>().transform;

    void Update()
    {
        if (playerCamera != null)
        {
            transform.LookAt(playerCamera);
            transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.position);
        }
    }

    public void OpenCanvas(string message, Vector3 position)
    {
        canvasText.text = message;
        canvas.transform.position = position;
        image.enabled = true;
        canvas.SetActive(true);
    }

    public void OpenLockedMessage(string message, Vector3 position)
    {
        canvasText.text = message;
        canvas.transform.position = position;
        image.enabled = false;
        canvas.SetActive(true);
    }

    public void CloseCanvas()=>canvas.SetActive(false);   
}