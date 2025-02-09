using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "InventorySO", menuName = "Scriptable Objects/InventorySO")]
public class InventorySO : ScriptableObject
{
    private List<InventoryItemSO> items = new List<InventoryItemSO>();

    public List<InventoryItemSO> GetItems { get { return items; } }

    public void AddItem(InventoryItemSO item)
    {
        items.Add(item);
    }

    public void RemoveItem(InventoryItemSO Item)
    {
        items.Remove(Item);
    }

    public bool HasItem (InventoryItemSO Item)
    {
        return items.Contains(Item);
    }

}
