using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public static bool PlayerSafe;
    public Collider2D col;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSafe = false;   
    }
    public void OnColliderEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerSafe = true;
            anim.SetTrigger("Open");
        } 
    }
    public void OnColliderExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerSafe = false;
            anim.SetTrigger("Open");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
