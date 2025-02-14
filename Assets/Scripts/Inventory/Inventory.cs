using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private InventorySO inventorySO;
    [SerializeField] private Transform inventoryParent;
    [SerializeField] private GameObject slotPrefab;

    private InventoryItemSO selectedItem;

    public InventoryItemSO SelectedItem { get { return selectedItem; } set { selectedItem = value; } }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        
    }

    void UpdateInventroyUI()
    {

        for (int i = 0; i < inventoryParent.childCount; i++)
        {
            Destroy(inventoryParent.GetChild(i));
        }

        List<InventoryItemSO> inv = inventorySO.GetItems;
        foreach (InventoryItemSO item in inv)
        {
            var newSlot = Instantiate(slotPrefab, inventoryParent);
            InitializeSlot(newSlot, item);
        }
    }

    void InitializeSlot(GameObject slot, InventoryItemSO item)
    {
        slot.GetComponent<Image>().sprite = item.icon;
    }

    public void AddItem(InventoryItemSO item)
    {
        inventorySO.AddItem(item);
        UpdateInventroyUI();
    }

    public void RemoveItem(InventoryItemSO item)
    {
        inventorySO.RemoveItem(item);
        UpdateInventroyUI();
    }

    bool HasItem(InventoryItemSO item)
    {
        return inventorySO.HasItem(item);
    }
    
}
