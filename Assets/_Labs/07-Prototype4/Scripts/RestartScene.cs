using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reloads the currently active scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}