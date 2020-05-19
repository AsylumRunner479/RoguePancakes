using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTableComponent : MonoBehaviour
{
    [Header("Crafting Recipe")]
    public List<GameObject> CraftingResult;
    public List<int> CraftingResultAmount;
    public List<GameObject> CraftingRecipe;
    public List<GameObject> CraftingRecipeAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.SqrMagnitude(PlayerController.Instance.transform.position - transform.position) < 5)
            Debug.Log("Close");
    }
}
