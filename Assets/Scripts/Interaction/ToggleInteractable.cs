using UnityEngine;
using UnityEngine.Events;

public class ToggleInteractable : BaseInteractable
{
    [SerializeField] private bool status;
    [SerializeField] private UnityEvent onToggle;
    [SerializeField] private UnityEvent onToggleOn;
    [SerializeField] private UnityEvent onToggleOff;

    public override void OnInteract()
    {
        ToggleStatus();
    }

    void ToggleStatus()
    {
        status = !status;
        onToggle.Invoke();

        if (status)
        {
            OnToggleOn();
        }
        else
        {
            OnToggleOff();
        }
    }

    void OnToggleOn()
    {
        onToggleOn.Invoke();
    }

    void OnToggleOff()
    {
        onToggleOff.Invoke();
    }
}
