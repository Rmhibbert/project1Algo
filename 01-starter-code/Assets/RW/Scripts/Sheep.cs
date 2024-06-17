using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float dropDestroyDelay;
    private bool dropped;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    public GameObject HeartFeedbackPrefab;



    private void Awake()
    {
        // Get the required components
        myCollider = GetComponent<BoxCollider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(-transform.forward * runSpeed * Time.deltaTime);

    }

    private void HitByHay()
    {
        Debug.Log("Hit by Hay - Destroying Sheep");
        Destroy(gameObject); // Destroy the sheep
        SFXManager.Instance.PlaySheepHitSound();
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
        Debug.Log("Collision detected with: " + other.tag);

        // If we collided with hay:
        if (other.CompareTag("Hay"))
        {
            Debug.Log("Collided with Hay");
            Destroy(other.gameObject);
            HitByHay();
            GameObject heartFeedback = Instantiate(HeartFeedbackPrefab, transform.position, Quaternion.identity);
            HeartFeedback heartFeedbackScript = heartFeedback.GetComponent<HeartFeedback>();
            if (heartFeedbackScript != null)
            {
                heartFeedbackScript.SetupAndPlay(transform.position);
            }
        }
        // If we collided with the edge of the map:
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Debug.Log("Collided with DropSheep");
            Drop();
            SFXManager.Instance.PlaySheepDroppedSound();
        }
    }
}
