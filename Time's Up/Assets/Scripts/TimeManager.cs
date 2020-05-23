using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public SpawnManager spawn;
    public float time;
    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        time = 50;  
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else if (ElevatorManager.PlayerSafe == false)
        {
            
            GameManager.isDead = true;
        }
        else
        {
            SpawnManager.endlevel = true;
            
            spawn.anotherLevel();

        }
    }
}
