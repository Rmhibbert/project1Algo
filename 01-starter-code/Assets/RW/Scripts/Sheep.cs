using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float dropDestroyDelay;
    private bool dropped;
    private Collider myCollider;
    private Rigidbody myRigidbody;

    private void Awake()
    {
        // GetComponent is a special Unity function that gets a reference to a component
        // that is also on this same GameObject. The type provided in the < > is what
        // type of component the function will look for.
        //
        // Tip: If the component that you want is on a child of this GameObject, you can
        // use GetComponentInChildren<>()
        myCollider = GetComponent<BoxCollider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Move forwards
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        Destroy(gameObject);
    }

    private void Drop()
    {
        // Make gravity start affecting us, then destroy after a delay.
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If we collided with hay:
        if (other.CompareTag("Hay"))
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        // If we collided with the edge of the map:
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }
}