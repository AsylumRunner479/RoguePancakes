using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("Slot Variable")]
    public GameObject ItemObject;

    [Header("Visible Variables")]
    public GameObject Item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool HasItem() { return Item != null; }

    public void SetItem(GameObject _item)
    {
        Item = _item;
        ItemObject.GetComponent<Image>().sprite = _item.GetComponent<SpriteRenderer>().sprite;
    }
}
