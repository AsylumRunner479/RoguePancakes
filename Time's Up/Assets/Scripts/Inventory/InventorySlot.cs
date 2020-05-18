using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Slot Variable")]
    public GameObject ItemObject;
    public Text ItemNumText;

    [Header("Visible Variables")]
    [Header("Setup")]
    public InventoryDisplay InventoryDisplay;
    public Canvas Canvas;
    [Header("Item")]
    public GameObject Item;
    public int NumberOfItems;
    [Header("Drag")]
    public GameObject PickedUpItem;
    public GameObject PickedUpItemObject;
    public int PickedUpNum;
    [Header("Observable Variables")]
    public List<Action<ItemComponent>> OnItemAdded;
    public List<Action<ItemComponent>> OnItemRemoved;

    [Header("Testing Variables")]
    public int InventorySlotNum;
    public Vector3 InitialDragPosition;
    public Vector3 InitialDragDelta;
    public Vector3 InitialMouseDown;

    void Start()
    {
        transform.SetSiblingIndex(InventorySlotNum);

        OnItemAdded = new List<Action<ItemComponent>>();
        OnItemRemoved = new List<Action<ItemComponent>>();
    }

    //Initializes the slot (Is called by inventory display)
    public void InitializeSlot(Canvas _canvas, InventoryDisplay _display)
    {
        InitialDragPosition = ItemObject.transform.position;
        ItemObject.SetActive(false);
        Canvas = _canvas;
        InventoryDisplay = _display;
    }

    //Main bulk of drag and drop functionality
    public void OnPointerDown(PointerEventData eventData)
    {
        InitialMouseDown = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ItemObject.activeSelf)
        {
            PickedUpItemObject = Instantiate(ItemObject, transform);
            PickedUpItemObject.transform.SetParent(Canvas.transform);
            PickedUpItemObject.transform.SetAsLastSibling();

            InitialDragDelta = InitialMouseDown - PickedUpItemObject.transform.position;

            PickedUpItem = Item;
            PickedUpNum = NumberOfItems;

            RemoveItem(PickedUpNum);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (PickedUpItemObject != null)
        {
            PickedUpItemObject.transform.position = ((Vector3)eventData.position - InitialDragDelta) / Canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (PickedUpItemObject != null)
        {
            Destroy(PickedUpItemObject);

            int amountLeft = InventoryDisplay.DropItemIntoSlot(PickedUpItem, PickedUpNum);

            if (amountLeft > 0)
                SetItem(PickedUpItem, amountLeft);

            PickedUpItem = null;
            PickedUpNum = 0;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryDisplay.PointerEnterSlot(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryDisplay.PointerExitSlot(this);
    }

    //Inventory slot functionality
    public bool IsThereItem() { return Item != null; }
    public bool HasItem(string _itemId)
    {
        if (!IsThereItem())
            return false;

        return Item.GetComponent<ItemComponent>().ItemId == _itemId;
    }

    //Returns the number of leftover items
    public int AddItem(GameObject _item, int _num)
    {
        ItemComponent item = _item.GetComponent<ItemComponent>();
        ItemComponent currItem = IsThereItem() ? Item.GetComponent<ItemComponent>() : null;

        if (currItem  == null || currItem.ItemId == item.ItemId)
        {
            int amount = (int)Mathf.Min(item.NumberPerStack, NumberOfItems + _num);
            int initialNumber = NumberOfItems;

            SetItem(_item, amount);
            return _num + initialNumber - amount;
        }

        return _num;
    }
    public int RemoveItem() { RemoveItem(NumberOfItems); return 0; }
    //Returns the number of items you still need to remove
    public int RemoveItem(int _num)
    {
        int prevNum = NumberOfItems;

        SetNumOfItems(NumberOfItems - _num);

        return _num - prevNum;
    }

    public void SetItem(GameObject _item, int _num)
    {
        ItemObject.SetActive(true);
        Item = _item;
        ItemObject.GetComponent<Image>().sprite = _item.GetComponent<SpriteRenderer>().sprite;

        SetNumOfItems(_num);
    }
    public void SetNumOfItems(int _num)
    {
        if (Item == null)
            throw new Exception("Item has not been set");

        if (_num > 0 && NumberOfItems <= 0)
            ItemAdded(Item.GetComponent<ItemComponent>());

        NumberOfItems = _num;

        if (NumberOfItems <= 0)
        {
            ItemRemoved(Item.GetComponent<ItemComponent>());
            NumberOfItems = 0;
            ItemObject.SetActive(false);
            Item = null;
        }

        ItemNumText.text = NumberOfItems + "";
        ItemNumText.transform.parent.gameObject.SetActive(NumberOfItems > 1);

    }

    //Actions from any observer
    void ItemRemoved(ItemComponent _item)
    {
        for (int i = 0; i < OnItemRemoved.Count; i++)
            OnItemRemoved[i](_item);
    }
    void ItemAdded(ItemComponent _item)
    {
        for (int i = 0; i < OnItemAdded.Count; i++)
            OnItemAdded[i](_item);
    }

    public void AddItemAddedAction(Action<ItemComponent> _itemAdded) { OnItemAdded.Add(_itemAdded); }
    public void RemoveItemAddedAction(Action<ItemComponent> _itemAdded) { OnItemAdded.Remove(_itemAdded); }
    public void AddItemRemovedAction(Action<ItemComponent> _itemRemoved) { OnItemRemoved.Add(_itemRemoved); }
    public void RemoveItemRemovedAction(Action<ItemComponent> _itemRemoved) { OnItemRemoved.Remove(_itemRemoved); }
}
