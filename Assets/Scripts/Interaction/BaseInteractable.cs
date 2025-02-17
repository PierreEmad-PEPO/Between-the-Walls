using TMPro;
using UnityEngine;


public class BaseInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] protected string message;
    [SerializeField] protected string hintMessage;
    [SerializeField] protected Vector3 offset;
    [SerializeField] protected bool isLocked = false; // should to be saved saved in CSV or Json

    public bool IsLocked { get { return isLocked; } }


    public virtual void OnInteract()
    {
        GetInstanceID();
    }

    public virtual void OnPlayerEnter()
    {
        if (!isLocked)
            InteractorCanvas.Instance.OpenCanvas(message, transform.position + offset);
        else
            InteractorCanvas.Instance.OpenLockedMessage(hintMessage, transform.position + offset);
    }

    public virtual void OnPlayerExit()
    {
        InteractorCanvas.Instance.CloseCanvas();
    }
    public virtual void AllowInteraction()
    {
        isLocked = false;
    }

    public virtual void LockInteraction()
    {
        isLocked = true;
    }

   
   
}
