using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrderComponent : MonoBehaviour
{
    [Header("Visible Variables")]
    public SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer.sortingOrder = (int) -transform.position.y;
    }
}
