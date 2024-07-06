using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject obstacle;  // Reference to the Prefab to spawn
    public Transform spawnPoint;      // Location where the object will be spawned
    public float spawnInterval = 2f;  // Time interval between spawns

    private float timeSinceLastSpawn;

    void Start()
    {
        timeSinceLastSpawn = 0f;
    }

    void Update()
    {
        // Update the time since the last spawn
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it's time to spawn a new object
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f; // Reset the spawn timer
        }
    }

    void SpawnObject()
    {
        //spawn Fly every ? seconds
        Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation);
    }
}