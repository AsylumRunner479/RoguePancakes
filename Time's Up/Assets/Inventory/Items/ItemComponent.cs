using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemComponent : MonoBehaviour
{
    [Header("Item Variables")]
    public string ItemId;
    public float NumberPerStack = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnSelect() { Debug.Log("Select"); }
    public virtual void OnUse(Vector3 _mousePosition) { Debug.Log("Use"); }
    public virtual void OnDeselect() { Debug.Log("Deselect"); }
}
