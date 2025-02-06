using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float senstivity=100f;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        xRotation = transform.localRotation.eulerAngles.x;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * senstivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * senstivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}