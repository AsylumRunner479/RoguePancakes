using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Inventory Controller
public class InventoryDisplay : MonoBehaviour
{
    [Header("Inventory Prefabs")]
    public Canvas Canvas;
    public GameObject InventorySlotSection;
    public GameObject Toolkit;

    [Header("Visible Variables")]
    public GameObject[] InventorySlots;
    public GameObject[] ToolkitSlots;
    public InventorySlot LatestEntered;

    // Start is called before the first frame update
    void Start()
    {
        InventorySlots = InitializeSlots(InventorySlotSection);
        ToolkitSlots = InitializeSlots(Toolkit);
    }

    //Initializes inventory slots
    GameObject[] InitializeSlots(GameObject _parent)
    {
        GameObject[] slots = new GameObject[_parent.transform.childCount];

        for (int i = 0; i < _parent.transform.childCount; i++)
        {
            GameObject slot = _parent.transform.GetChild(i).gameObject;
            InventorySlot slotComponent = slot.GetComponent<InventorySlot>();

            slotComponent.InitializeSlot(Canvas, this);

            slots[slotComponent.InventorySlotNum] = slot;
        }

        return slots;
    }

    //Enables drag and drop functionality (most functionality can be found in InventorySlot)
    public void PointerEnterSlot(InventorySlot _slot) { LatestEntered = _slot; }
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

    public bool HasItem(string _itemId, int _amount)
    {
        foreach(GameObject inventorySlot in GetMainInventorySlots())
        {
            InventorySlot slot = inventorySlot.GetComponent<InventorySlot>();

            if (slot.HasItem(_itemId))
                _amount -= slot.NumberOfItems;

            if (_amount <= 0) return true;
        }

        return false;
    }
    public bool HasItem(List<GameObject> _items, List<int> _amounts)
    {
        for (int i = 0; i < _items.Count; i++)
            if (!HasItem(_items[i].GetComponent<ItemComponent>().ItemId, _amounts[i]))
                return false;

        return true;
    }

    public void RemoveItem(string _itemId, int _amount)
    {
        foreach (GameObject inventorySlot in GetMainInventorySlots())
        {
            InventorySlot slot = inventorySlot.GetComponent<InventorySlot>();

            if (slot.HasItem(_itemId))
            {
                _amount = slot.RemoveItem(_amount);
            }

            if (_amount <= 0)
                return;
        }
    }
    public void RemoveItem(List<GameObject> _items, List<int> _amounts)
    {
        for (int i = 0; i < _items.Count; i++)
            RemoveItem(_items[i].GetComponent<ItemComponent>().ItemId, _amounts[i]);
    }

    List<GameObject> GetMainInventorySlots()
    {
        List<GameObject> mainSlots = new List<GameObject>();
        mainSlots.AddRange(InventorySlots);
        mainSlots.AddRange(ToolkitSlots);

        return mainSlots;
    }
}
