using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemUserComponent : MonoBehaviour
{
    [Header("Item User Variables")]
    public ToolkitDisplay Toolkit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ItemComponent item = Toolkit.GetSelectedItem();

            if (item != null)
                item.OnUse(Vector3.zero);
        }
    }
}
