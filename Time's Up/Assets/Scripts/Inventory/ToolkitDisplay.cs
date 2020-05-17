using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Toolkit refers to the characters main inventory slot
public class ToolkitDisplay : MonoBehaviour
{
    [Header("Toolkit Variable")]
    public Sprite SelectedSprite;
    public GameObject ToolkitContainer;

    [Header("Visible Variables")]
    public GameObject[] ToolkitSlots;
    public int SelectedSlotIndex;
    public Sprite BasicInventorySprite;

    //Observer Variables
    private Action<ItemComponent> ItemAdded;
    private Action<ItemComponent> ItemRemoved;

    private KeyCode[] NumberKeyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };

    // Start is called before the first frame update
    void Start()
    {
        ToolkitSlots = new GameObject[ToolkitContainer.transform.childCount];
        for(int i = 0; i < ToolkitSlots.Length; i++)
        {
            GameObject toolkitSlot = ToolkitContainer.transform.GetChild(i).gameObject;
            InventorySlot slotComponent = toolkitSlot.GetComponent<InventorySlot>();
            ToolkitSlots[slotComponent.InventorySlotNum] = toolkitSlot;

            if (BasicInventorySprite == null)
                BasicInventorySprite = toolkitSlot.GetComponent<Image>().sprite;
        }

        //Auto Selects the First Slot
        SelectSlot(0);
    }

    void SelectSlot(int _index)
    {
        if (SelectedSlotIndex != -1)
            DeselectSlot(SelectedSlotIndex);

        SelectedSlotIndex = _index;

        ToolkitSlots[SelectedSlotIndex].GetComponent<Image>().sprite = SelectedSprite;

        ItemAdded = (_item) => _item.OnSelect();
        ItemRemoved = (_item) => _item.OnDeselect();
        InventorySlot slotComponent = ToolkitSlots[SelectedSlotIndex].GetComponent<InventorySlot>();
        slotComponent.AddItemAddedAction(ItemAdded);
        slotComponent.AddItemRemovedAction(ItemRemoved);

        ItemComponent item = GetItemOfSlot(SelectedSlotIndex);
        if (item != null)
            item.OnSelect();
    }

    void DeselectSlot(int _index)
    {
        ToolkitSlots[_index].GetComponent<Image>().sprite = BasicInventorySprite;

        InventorySlot slotComponent = ToolkitSlots[SelectedSlotIndex].GetComponent<InventorySlot>();
        slotComponent.RemoveItemAddedAction(ItemAdded);
        slotComponent.RemoveItemRemovedAction(ItemRemoved);

        ItemComponent item = GetItemOfSlot(_index);
        if (item != null)
            item.OnDeselect();
    }

    ItemComponent GetItemOfSlot(int _index)
    {
        InventorySlot slot = ToolkitSlots[_index].GetComponent<InventorySlot>();
        if(!slot.IsThereItem())
            return null;

        return slot.Item.GetComponent<ItemComponent>();
    }

    void SelectNextSlot(int _amount)
    {
        int nextSlotIndex = (SelectedSlotIndex + _amount) % ToolkitSlots.Length;
        if (nextSlotIndex < 0)
            nextSlotIndex += ToolkitSlots.Length;

        SelectSlot(nextSlotIndex);
    }

    // Update is called once per frame
    void Update()
    {
        //Allows you to click through your numbers
        for (int i = 0; i < NumberKeyCodes.Length; i++)
            if (Input.GetKeyDown(NumberKeyCodes[i]) && i < ToolkitSlots.Length)
                SelectSlot(i);

        //Allows you to scroll through toolkit
        float rawScrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (rawScrollInput != 0)
        {
            SelectNextSlot((int) -Mathf.Sign(rawScrollInput));
        }
    }

    public ItemComponent GetSelectedItem()
    {
        return GetItemOfSlot(SelectedSlotIndex);
    }

}
