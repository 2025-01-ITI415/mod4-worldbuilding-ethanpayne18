using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float launchMultiplier = 2f; // Multiplier for force

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 launchDirection = rb.velocity.normalized;
                rb.AddForce(launchDirection * launchMultiplier, ForceMode.Impulse);
            }
        }
    }
}