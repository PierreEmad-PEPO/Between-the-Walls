using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractorCanvas : MonoBehaviour
{
    [SerializeField] protected GameObject canvas;
    [SerializeField] protected TextMeshProUGUI canvasText;
    [SerializeField] protected Image image;

    public static InteractorCanvas Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        CloseCanvas();
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

    public void CloseCanvas()
    {
        canvas.SetActive(false);
    }
}
