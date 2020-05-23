using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton

    public static PlayerController Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [Header("Player Variables")]
    public int Health = 7;
    
    [Header("Visible Variables")]
    public Vector3 Direction;

    public GameObject[] healthBars;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        for (int i = 0; i < healthBars.Length; i++)
        {
            if (Health <= i)
            {
                healthBars[i].SetActive(false);
            }
            else
            {
                healthBars[i].SetActive(true);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    private void Move()
    {
        Direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        GetComponent<MoveComponent>().SetDirection(Direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Item")
        {
            if (InventoryDisplay.Instance.AddItem(collision.gameObject, 1) <= 0)
                collision.gameObject.SetActive(false);
        }
        if (collision.tag == "crafting")
        {
            
        }
    }
}
