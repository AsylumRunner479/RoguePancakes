using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = Vector3.zero;

        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        GetComponent<MoveComponent>().SetDirection(direction);
    }
}
