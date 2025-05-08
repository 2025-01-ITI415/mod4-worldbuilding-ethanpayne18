using UnityEngine;

public class CollectibleDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameHUD>().UpdateCollectibleCount();
            Destroy(gameObject);
        }
    }
}