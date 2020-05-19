using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int robotSpawnCount;
    public GameObject robot;
    public int cyborgSpawnCount;
    public GameObject cyborg;
    public int batterySpawnCount;
    public GameObject battery;
    public int LabBenchSpawnCount;
    public GameObject LabBench;
    public int OfficeBenchSpawnCount;
    public GameObject OfficeBench;
    public int SteelSpawnCount;
    public GameObject Steel;
    public int woodSpawnCount;
    public GameObject wood;
    public int WorkBenchSpawnCount;
    public GameObject WorkBench;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime * 25;
        if (robotSpawnCount >= 0)
        {
            Instantiate(robot);
            robotSpawnCount -= 1;
        }
        if (cyborgSpawnCount >= 0)
        {
            Instantiate(cyborg);
            cyborgSpawnCount -= 1;
        }
        if (batterySpawnCount >= 0)
        {
            Instantiate(battery);
            batterySpawnCount -= 1;
        }
        if (LabBenchSpawnCount >= 0)
        {
            Instantiate(LabBench);
            LabBenchSpawnCount -= 1;
        }
        if (OfficeBenchSpawnCount >= 0)
        {
            Instantiate(OfficeBench);
            OfficeBenchSpawnCount -= 1;
        }
        if (SteelSpawnCount >= 0)
        {
            Instantiate(Steel);
            SteelSpawnCount -= 1;
        }
        if (woodSpawnCount >= 0)
        {
            Instantiate(wood);
            woodSpawnCount -= 1;
        }
        if (WorkBenchSpawnCount >= 0)
        {
            Instantiate(WorkBench);
            WorkBenchSpawnCount -= 1;
        }
    }
}
