using UnityEngine;

public class Interactor : MonoBehaviour
{
    private IInteractable currentInteractable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        if (currentInteractable == null) return;

        currentInteractable.OnInteract();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("55555555");
        if (!other.CompareTag("Interactable")) return;

        // Ensure previous interactable is properly exited
        if (currentInteractable != null)
        {
            currentInteractable.OnPlayerExit();
        }

        if (other.TryGetComponent(out IInteractable interactable))
        {
            currentInteractable = interactable;
            currentInteractable.OnPlayerEnter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Interactable") || currentInteractable == null) return;

        currentInteractable.OnPlayerExit();
        currentInteractable = null;
    }
}
