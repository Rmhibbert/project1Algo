using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hayMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float movementSpeed = 10f;
    public float horizontalBoundary = 21;
    public GameObject hayBalePrefab;
    public Transform haySpawnPoint;
    public float shootInterval;
    public float shootTimer;




    // Update is called once per frame
    void Update()
    {
        MachineMove();
        ShootHandling();

    }

    void MachineMove()
    {
        float input = Input.GetAxis("Horizontal");

        if (input < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);

        }
        else if (input > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);

        }
    }

    void ShootHandling()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }

    }


    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnPoint.position, Quaternion.identity);
    }
}
