using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [Header("Inventory Prefabs")]
    public Canvas Canvas;
    public GameObject InventorySlotSection;

    [Header("Test Variables")]
    public List<GameObject> InventorySlots;
    public InventorySlot LatestEntered;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < InventorySlotSection.transform.childCount; i++)
        {
            GameObject inventorySlot = InventorySlotSection.transform.GetChild(i).gameObject;
            inventorySlot.GetComponent<InventorySlot>().InitializeSlot(Canvas, this);

            InventorySlots.Add(inventorySlot);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool AddItem(GameObject _item)
    {
        foreach (GameObject inventorySlot in InventorySlots)
        {
            if (inventorySlot.GetComponent<InventorySlot>().AddItem(_item))
            {
                Debug.Log(_item);
                
                return true;
            }
        }

        return false;
    }

    public bool AddItemTo(GameObject _item, InventorySlot _target)
    {
        return _target.AddItem(_item);
    }

    public void PointerEnterSlot(InventorySlot _slot) { LatestEntered = _slot; Debug.Log("Enter: " + _slot.InventorySlotNum); }
    public void PointerExitSlot(InventorySlot _slot)
    {
        if (LatestEntered == _slot)
            LatestEntered = null;
    }
    public bool DropItemIntoSlot(GameObject _item)
    {
        if (LatestEntered == null)
            return false;

        Debug.Log("Adding to " + LatestEntered.InventorySlotNum);

        bool result = LatestEntered.AddItem(_item);

        LatestEntered = null;

        return result;
    }
}
