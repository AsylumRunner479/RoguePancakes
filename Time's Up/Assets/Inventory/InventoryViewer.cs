using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LITERALLY JUST ALLOWS YOU TO CLICK TAB TO SEE INVENTORY
public class InventoryViewer : MonoBehaviour
{
    [Header("Inventory Variables")]
    public GameObject InventoryUI;

    [Header("Visible Variables")]
    public bool VisibleState = false;

    // Start is called before the first frame update
    void Start()
    {
        InventoryUI.SetActive(VisibleState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            VisibleState = !VisibleState;
            InventoryUI.SetActive(VisibleState);
        }
            
    }
}
