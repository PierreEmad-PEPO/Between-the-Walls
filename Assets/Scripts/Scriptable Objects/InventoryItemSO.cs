using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Scriptable Objects/InventoryItem")]
public class InventoryItemSO : ScriptableObject
{
    public int itemID;
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject itemPrefab;

    public virtual void OnItemUse()
    {
        // access the inventory and mark this as active item
    }

    public virtual GameObject SpawnItem(Vector3 position, Quaternion rotation)
    {
        if (itemPrefab != null)
        {
            return Instantiate(itemPrefab, position, rotation);
        }
        else
        {
            Debug.LogWarning($"No prefab assigned for {itemName}");
            return null;
        }
    }
}

