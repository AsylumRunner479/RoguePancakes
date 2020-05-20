using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public PlayerController player;
    public int damage;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(damage);
            Destroy(self);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
