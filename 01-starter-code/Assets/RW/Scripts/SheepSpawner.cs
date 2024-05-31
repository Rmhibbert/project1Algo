using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Random = System.Random;

public class SheepSpawner : MonoBehaviour
{
    public GameObject sheepPrefab;
    public float spawnInterval = 3f; 
    public Transform spawnPoint;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
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
            GameObject newSheep = Instantiate(sheepPrefab, locationSelect(), Quaternion.identity);

            newSheep.transform.rotation = sheepPrefab.transform.rotation;

        }
    }

    private Vector3 locationSelect() 
    {
        var location = spawnPoint.position; 
        Random rand = new Random();
        int number = rand.Next(1,4);

       switch (number){
            case 1:
                location = spawnPoint.position;
                break;
            case 2:
                location = spawnPoint1.position;
                break;
            case 3:
                location = spawnPoint2.position;
                break;
        }
        

        return location;
    }

}

