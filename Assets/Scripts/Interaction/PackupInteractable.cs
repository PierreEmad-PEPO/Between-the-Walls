using UnityEngine;

public class PickupInteractable : BaseInteractable
{
    [SerializeField] InventoryItemSO itemSO;
    public override void OnInteract()
    {
        base.OnInteract();

        Inventory.Instance.AddItem(itemSO);
        canvas.SetActive(false);
        Destroy(gameObject);
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
