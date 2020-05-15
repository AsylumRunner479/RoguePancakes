using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolkitDisplay : MonoBehaviour
{
    [Header("Toolkit Variable")]
    public Sprite SelectedSprite;
    public GameObject ToolkitContainer;

    [Header("Visible Variables")]
    public GameObject[] ToolkitSlots;
    public int SelectedSlotIndex;
    public Sprite BasicInventorySprite;

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
            ToolkitSlots[i] = toolkitSlot;

            if (BasicInventorySprite == null)
                BasicInventorySprite = toolkitSlot.GetComponent<Image>().sprite;
        }

        SelectSlot(0);
    }

    void SelectSlot(int _num)
    {
        if (SelectedSlotIndex != -1)
            ToolkitSlots[SelectedSlotIndex].GetComponent<Image>().sprite = BasicInventorySprite;

        SelectedSlotIndex = _num;

        ToolkitSlots[SelectedSlotIndex].GetComponent<Image>().sprite = SelectedSprite;
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
        for (int i = 0; i < NumberKeyCodes.Length; i++)
            if (Input.GetKeyDown(NumberKeyCodes[i]))
                SelectSlot(i);

        float rawScrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (rawScrollInput != 0)
        {
            SelectNextSlot((int) -Mathf.Sign(rawScrollInput));
        }
    }
}
