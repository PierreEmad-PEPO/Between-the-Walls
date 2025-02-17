using UnityEngine;
using UnityEngine.Events;

public class PickupInteractable : BaseInteractable
{
    [SerializeField] InventoryItemSO itemSO;
    [SerializeField] BaseInteractable unlockItem;

    public UnityEvent onPickup;  
    public override void OnInteract()
    {
        base.OnInteract();

        Inventory.Instance.AddItem(itemSO);
        InteractorCanvas.Instance.CloseCanvas();

        if (unlockItem != null)
            unlockItem.AllowInteraction();

        onPickup.Invoke();

        Destroy(gameObject);

        
        // play player animation and freeze player movements while animation is running 
        // play interaction sound
    }

    public override void OnPlayerEnter()
    {
        base.OnPlayerEnter();
        Debug.Log("Player Entered");
    }

    public override void OnPlayerExit()
    {
        base.OnPlayerExit();
        Debug.Log("Player Exited");
    }

}
