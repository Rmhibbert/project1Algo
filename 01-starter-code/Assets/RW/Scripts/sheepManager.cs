using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepManager : MonoBehaviour
{
    public GameObject sheepPrefab;
    public float spawnInterval;
    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSheep", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        Instantiate(sheepPrefab, spawnPosition, Quaternion.identity);
    }


}

