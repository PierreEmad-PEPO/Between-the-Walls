using UnityEngine;

public interface IInteractable
{
    // call when player press E
    public void OnInteract();
    public void OnPlayerEnter();
    public void OnPlayerExit();
}
