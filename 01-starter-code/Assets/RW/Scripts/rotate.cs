using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public float rotationSpeedY;
    public float rotationSpeedX;
    public float rotationSpeedZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeedX, rotationSpeedY * Time.deltaTime, rotationSpeedX);
    }
}
