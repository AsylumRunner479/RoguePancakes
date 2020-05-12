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

        Debug.Log("Adding to " + LatestEntered.InventorySlotNum);

        int result = LatestEntered.AddItem(_item, _num);

        LatestEntered = null;

        return result;
    }
}
