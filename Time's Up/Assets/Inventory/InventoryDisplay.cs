using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [Header("Inventory Prefabs")]
    public Canvas Canvas;
    public GameObject InventorySlotSection;
    public GameObject Toolkit;

    [Header("Test Variables")]
    public GameObject[] InventorySlots;
    public GameObject[] ToolkitSlots;
    public InventorySlot LatestEntered;

    // Start is called before the first frame update
    void Start()
    {
        InventorySlots = new GameObject[InventorySlotSection.transform.childCount];
        for(int i = 0; i < InventorySlotSection.transform.childCount; i++)
        {
            GameObject inventorySlot = InventorySlotSection.transform.GetChild(i).gameObject;
            InventorySlot slotComponent = inventorySlot.GetComponent<InventorySlot>();

            slotComponent.InitializeSlot(Canvas, this);

            InventorySlots[slotComponent.InventorySlotNum] = inventorySlot;
            
        }

        ToolkitSlots = new GameObject[Toolkit.transform.childCount];
        for(int i = 0; i < Toolkit.transform.childCount; i++)
        {
            GameObject toolkitSlot = Toolkit.transform.GetChild(i).gameObject;
            InventorySlot slotComponent = toolkitSlot.GetComponent<InventorySlot>();

            slotComponent.InitializeSlot(Canvas, this);

            ToolkitSlots[slotComponent.InventorySlotNum] = toolkitSlot;
        }
    }

    public int AddItem(GameObject _item, int _num)
    {
        foreach (GameObject inventorySlot in InventorySlots)
        {
            _num = inventorySlot.GetComponent<InventorySlot>().AddItem(_item, _num);

            if (_num <= 0)
                break;
        }

        return _num;
    }

    public int AddItemTo(GameObject _item, int _num, InventorySlot _target)
    {
        return _target.AddItem(_item, _num);
    }

    public void PointerEnterSlot(InventorySlot _slot) { LatestEntered = _slot; Debug.Log("Enter: " + _slot.InventorySlotNum); }
    public void PointerExitSlot(InventorySlot _slot)
    {
        if (LatestEntered == _slot)
            LatestEntered = null;
    }
    public int DropItemIntoSlot(GameObject _item, int _num)
    {
        if (LatestEntered == null)
            return _num;

        int result = LatestEntered.AddItem(_item, _num);

        LatestEntered = null;

        return result;
    }

    public bool HasItem(string _itemId, int _amount)
    {
        foreach(GameObject inventorySlot in InventorySlots)
        {
            InventorySlot slot = inventorySlot.GetComponent<InventorySlot>();

            if (slot.HasItem(_itemId))
                _amount -= slot.NumberOfItems;

            if (_amount <= 0) return true;
        }

        return false;
    }

    public bool HasItem(List<string> _itemIds, List<int> _amounts)
    {
        for (int i = 0; i < _itemIds.Count; i++)
            if (!HasItem(_itemIds[i], _amounts[i]))
                return false;

        return true;
    }
}
