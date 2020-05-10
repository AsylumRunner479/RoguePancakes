using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [Header("Inventory Prefabs")]
    public GameObject InventorySlotSection;

    [Header("Test Variables")]
    public List<GameObject> InventorySlots;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < InventorySlotSection.transform.childCount; i++)
        {
            GameObject inventorySlot = InventorySlotSection.transform.GetChild(i).gameObject;

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
            if (inventorySlot.GetComponent<InventorySlot>().HasItem())
                return true;
        }

        return false;
    }
}
