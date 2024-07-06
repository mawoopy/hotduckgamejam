using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject obstacle;  // Reference to the Prefab to spawn
    public GameObject fly;  // Reference to the Prefab to spawn
    public Transform spawnPoint;      // Location where the object will be spawned
    public float spawnInterval = 2f;  // Time interval between spawns

    private float timeSinceLastSpawn;

    void Start()
    {
        obstacle = GameObject.Find("Obstacle");

        obstacle = GameObject.Find("Fly");

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
        //spawn Obstacle every ? seconds
        Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation);

        //spawn Fly every ? seconds
        Instantiate(fly, spawnPoint.position, spawnPoint.rotation);
    }
}