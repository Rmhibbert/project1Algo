using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 30f;
    public GameObject endZone;
    // Update is called once per frame
    void Update()
    {
        movement();
    }


    void movement()
    {   
       transform.Translate(transform.forward * speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider endzone)
    {
        Destroy(gameObject);
    }
   
}
