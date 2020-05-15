using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    [Header("Testing Variables")]
    public int InventorySlotNum;
    public Vector3 InitialDragPosition;
    public Vector3 InitialDragDelta;
    public Vector3 InitialMouseDown;

    void Start()
    {
        transform.SetSiblingIndex(InventorySlotNum);
    }

    public void InitializeSlot(Canvas _canvas, InventoryDisplay _display)
    {
        InitialDragPosition = ItemObject.transform.position;
        ItemObject.SetActive(false);
        Canvas = _canvas;
        InventoryDisplay = _display;
    }

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
            //Debug.Log("Start " + InventorySlotNum);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (PickedUpItemObject != null)
        {
            PickedUpItemObject.transform.position = ((Vector3)eventData.position - InitialDragDelta) / Canvas.scaleFactor;
            //Debug.Log("Drag " + InventorySlotNum);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (PickedUpItemObject != null)
        {
            Destroy(PickedUpItemObject);

            int amountLeft = InventoryDisplay.DropItemIntoSlot(PickedUpItem, PickedUpNum);

            if (amountLeft <= 0)
                RemoveItem();
            else
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

    public bool IsThereItem() { return Item != null; }
    public bool HasItem(string _itemId)
    {
        if (!IsThereItem())
            return false;

        return Item.GetComponent<ItemComponent>().ItemId == _itemId;
    }

    public int AddItem(GameObject _item, int _num)
    {
        ItemComponent item = _item.GetComponent<ItemComponent>();

        if (!IsThereItem())
        {
            int amount = (int)Mathf.Min(item.NumberPerStack, NumberOfItems + _num);
            int initialNumber = NumberOfItems;

            SetItem(_item, amount);
            return _num + initialNumber - amount;
        }

        ItemComponent currItem = Item.GetComponent<ItemComponent>();

        if (currItem.ItemId == item.ItemId)
        {
            int amount = (int)Mathf.Min(item.NumberPerStack, NumberOfItems + _num);
            int initialNumber = NumberOfItems;

            SetItem(_item, amount);
            return _num + initialNumber - amount;
        }

        return _num;
    }

    public void SetItem(GameObject _item, int _num)
    {
        ItemObject.SetActive(true);
        Item = _item;
        ItemObject.GetComponent<Image>().sprite = _item.GetComponent<SpriteRenderer>().sprite;

        SetNumOfItems(_num);
    }
    public void RemoveItem() { RemoveItem(NumberOfItems); }
    public void RemoveItem(int _num)
    {
        SetNumOfItems(NumberOfItems - _num);

        if (NumberOfItems <= 0)
        {
            ItemObject.SetActive(false);
            Item = null;
        }

    }

    public void SetNumOfItems(int _num)
    {
        NumberOfItems = _num;

        if (NumberOfItems < 0)
            NumberOfItems = 0;

        ItemNumText.text = NumberOfItems + "";
        ItemNumText.transform.parent.gameObject.SetActive(NumberOfItems > 1);

    }
}
