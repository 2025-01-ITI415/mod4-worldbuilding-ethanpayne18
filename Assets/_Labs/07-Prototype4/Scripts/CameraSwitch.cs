using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    private Camera playerCamera;
    private Camera altCamera;

    public bool switchBackOnExit = true;

    void Start()
    {
        playerCamera = GameObject.Find("Player Camera")?.GetComponent<Camera>();
        altCamera = GameObject.Find("AltCamera")?.GetComponent<Camera>();

        if (playerCamera != null)
        {
            playerCamera.enabled = true;
            playerCamera.gameObject.SetActive(true);
        }

        if (altCamera != null)
        {
            altCamera.enabled = false;
            altCamera.gameObject.SetActive(false); // Disable entire alt camera object
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerCamera != null)
            {
                playerCamera.enabled = false;
                playerCamera.gameObject.SetActive(false);
            }

            if (altCamera != null)
            {
                altCamera.gameObject.SetActive(true);
                altCamera.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && switchBackOnExit)
        {
            if (altCamera != null)
            {
                altCamera.enabled = false;
                altCamera.gameObject.SetActive(false);
            }

            if (playerCamera != null)
            {
                playerCamera.gameObject.SetActive(true);
                playerCamera.enabled = true;
            }
        }
    }
}