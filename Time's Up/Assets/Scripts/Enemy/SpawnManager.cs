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
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        anotherLevel();
    }
    public void alterSpawn()
    {
        spawnPoint.position = this.transform.position + new Vector3(Random.Range(0, 17), Random.Range(0, 17), 0);
    }
    public void anotherLevel()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime * 25;
        if (robotSpawnCount >= 0)
        {
            Instantiate(robot, spawnPoint.position, Quaternion.identity);
            alterSpawn();
            robotSpawnCount -= 1;
        }
        if (cyborgSpawnCount >= 0)
        {
            Instantiate(cyborg, spawnPoint.position, Quaternion.identity);
            alterSpawn();
            cyborgSpawnCount -= 1;
        }
        if (batterySpawnCount >= 0)
        {
            Instantiate(battery, spawnPoint.position, Quaternion.identity);
            alterSpawn();
            batterySpawnCount -= 1;
        }
        if (LabBenchSpawnCount >= 0)
        {
            Instantiate(LabBench, spawnPoint.position, Quaternion.identity);
            alterSpawn();
            LabBenchSpawnCount -= 1;
        }
        if (OfficeBenchSpawnCount >= 0)
        {
            Instantiate(OfficeBench, spawnPoint.position, Quaternion.identity);
            alterSpawn();
            OfficeBenchSpawnCount -= 1;
        }
        if (SteelSpawnCount >= 0)
        {
            Instantiate(Steel, spawnPoint.position, Quaternion.identity);
            alterSpawn();
            SteelSpawnCount -= 1;
        }
        if (woodSpawnCount >= 0)
        {
            Instantiate(wood, spawnPoint.position, Quaternion.identity);
            alterSpawn();
            woodSpawnCount -= 1;
        }
        if (WorkBenchSpawnCount >= 0)
        {
            Instantiate(WorkBench, spawnPoint.position, Quaternion.identity);
            alterSpawn();
            WorkBenchSpawnCount -= 1;
        }
    }
}
