using UnityEngine;
using System.Collections;

public class DisappearingPlatform : MonoBehaviour
{
    public float disappearDelay = 2f; // Time before it disappears

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeAndDisable());
        }
    }

    IEnumerator FadeAndDisable()
    {
        yield return new WaitForSeconds(disappearDelay);
        gameObject.SetActive(false);
    }
}