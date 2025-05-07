using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable or destroy the collectible
            Destroy(gameObject); // Destroys this collectible
        }
    }
}