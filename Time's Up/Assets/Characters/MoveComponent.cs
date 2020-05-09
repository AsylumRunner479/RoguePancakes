using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [Header("Movement Variables")]
    public float Speed;

    [Header("Testing Variables")]
    public Vector3 Direction;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + (Direction * Speed * Time.deltaTime));
        Direction = Vector3.zero;
    }

    public void SetDirection(Vector3 _direction) { Direction = _direction; }
}
