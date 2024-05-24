using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public GameObject sheepPrefab;
    public float spawnInterval = 3f; // Time between each sheep spawn
    public Transform spawnPoint; // Far side of the field

    private float timer = 0f;

    private void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // If it's time to spawn a sheep
        if (timer >= spawnInterval)
        {
            // Reset timer
            timer = 0f;

            // Spawn a sheep at the spawn point 
            GameObject newSheep = Instantiate(sheepPrefab, spawnPoint.position, Quaternion.identity);

            newSheep.transform.rotation = sheepPrefab.transform.rotation;

        }
    }
}

