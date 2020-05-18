using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public InventoryDisplay Inventory;
    public GameObject TestItem;
    public List<GameObject> CheckIds;
    public List<int> CheckAmounts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem()
    {
        Inventory.AddItem(TestItem, 1);
    }

    public void CheckItem()
    {
        Debug.Log(Inventory.HasItem(CheckIds, CheckAmounts));
    }

    public void RemoveItem()
    {
        Inventory.RemoveItem(CheckIds, CheckAmounts);
    }
}
