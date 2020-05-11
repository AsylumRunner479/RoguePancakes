using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Slot Variable")]
    public GameObject ItemObject;

    [Header("Visible Variables")]
    public InventoryDisplay InventoryDisplay;
    public Canvas Canvas;
    public GameObject Item;

    [Header("Testing Variables")]
    public float InventorySlotNum;
    public Vector3 InitialDragPosition;
    public Vector3 InitialDragDelta;
    public Vector3 InitialMouseDown;

    public void InitializeSlot(Canvas _canvas, InventoryDisplay _display)
    {
        InitialDragPosition = ItemObject.transform.position;
        ItemObject.SetActive(false);
        Canvas = _canvas;
        InventoryDisplay = _display;
    }

    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        InitialMouseDown = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ItemObject.activeSelf)
        {
            InitialDragDelta = InitialMouseDown - ItemObject.transform.position;
            //Debug.Log("Start " + InventorySlotNum);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ItemObject.activeSelf)
        {
            ItemObject.transform.position = ((Vector3)eventData.position - InitialDragDelta) / Canvas.scaleFactor;
            //Debug.Log("Drag " + InventorySlotNum);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ItemObject.activeSelf)
        {
            ItemObject.transform.position = InitialDragPosition;
            //Debug.Log("End " + InventorySlotNum);

            if (InventoryDisplay.DropItemIntoSlot(Item))
                RemoveItem();
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

    public bool HasItem() { return Item != null; }

    public bool AddItem(GameObject _item)
    {
        if (!HasItem())
        {
            SetItem(_item);
            return true;
        }

        return false;
    }

    public void SetItem(GameObject _item)
    {
        ItemObject.SetActive(true);
        Item = _item;
        ItemObject.GetComponent<Image>().sprite = _item.GetComponent<SpriteRenderer>().sprite;
    }
    public void RemoveItem()
    {
        ItemObject.SetActive(false);
        Item = null;
    }
}
