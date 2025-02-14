using TMPro;
using UnityEngine;

public class BaseInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject canvas;
    [SerializeField] protected TextMeshProUGUI canvasText;
    [SerializeField] protected string message;
    [SerializeField] protected Vector3 offSite;
    public virtual void OnInteract()
    {

    }

    public virtual void OnPlayerEnter()
    {
        canvasText.text = message;
        canvas.transform.position = transform.position + offSite;
        canvas.SetActive(true);
    }

    public virtual void OnPlayerExit()
    {
        canvas.SetActive(false);
    }

   
}
