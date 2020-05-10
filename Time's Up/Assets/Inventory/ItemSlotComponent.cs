using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotComponent : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Testing Variables")]
    public Vector3 InitialPosition;
    public Vector3 InitialDragDelta;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        InitialDragDelta = (Vector3) eventData.position - transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = (Vector3) eventData.position - InitialDragDelta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = InitialPosition;
    }
}
