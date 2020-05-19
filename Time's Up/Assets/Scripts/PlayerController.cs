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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
}
