using UnityEngine;

public class CameraSmoothTrigger : MonoBehaviour
{
    public float newSmoothSpeed = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraController camController = Camera.main.GetComponent<CameraController>();
            if (camController != null)
            {
                camController.smoothSpeed = newSmoothSpeed;
            }
        }
    }
}