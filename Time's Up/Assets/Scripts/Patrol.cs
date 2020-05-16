using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;
    public Transform wallDetection;
    
    private void Start()
    {
        
    }
    private void Update()
    {
        if (movingRight == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        RaycastHit2D wallinforight = Physics2D.Raycast(this.transform.position, Vector2.right, 1f);
        RaycastHit2D wallinfoleft = Physics2D.Raycast(this.transform.position, Vector2.left, 1f);
        RaycastHit2D wallinfoup = Physics2D.Raycast(this.transform.position, Vector2.up, 1f);
        RaycastHit2D wallinfodown = Physics2D.Raycast(this.transform.position, Vector2.down, 1f);
        if (wallinforight.collider == true || wallinfoleft.collider == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        if (wallinfoup.collider == true || wallinfodown.collider == true)
        {
            transform.eulerAngles = new Vector3(-180, 0, 0);
        }
    }
}
