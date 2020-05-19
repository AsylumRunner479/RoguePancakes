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
    public void OnColliderEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponent<PlayerController>();
            player.TakeDamage(damage);
            Destroy(self);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
