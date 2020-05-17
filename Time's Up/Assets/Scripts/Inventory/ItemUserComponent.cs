using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//LITERALLY JUST LETS YOU USE AN ITEM WHEN YOU CLICK SOMEWHERE ON THE SCREEN THAT IS NOT ON A GUI
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
