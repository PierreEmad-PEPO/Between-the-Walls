using UnityEngine;

public interface IInteractable
{
    // call when player press E

    public bool IsLocked { get; }
    public void OnInteract();
    public void OnPlayerEnter();
    public void OnPlayerExit();
    public void AllowInteraction();
    public void LockInteraction();

}
