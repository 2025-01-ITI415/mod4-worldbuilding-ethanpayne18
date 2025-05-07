using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float launchMultiplier = 20f;
    public bool zeroHorizontal = true;
    public float temporaryDrag = 10f;
    public float dragResetDelay = 0.2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (zeroHorizontal)
                {
                    // Kill horizontal momentum
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                }

                // Optional drag slowdown
                StartCoroutine(TemporaryDrag(rb));

                // Launch in upward-forward direction
                Vector3 launchDirection = (transform.forward + Vector3.up).normalized;
                rb.AddForce(launchDirection * launchMultiplier, ForceMode.Impulse);
            }
        }
    }

    System.Collections.IEnumerator TemporaryDrag(Rigidbody rb)
    {
        float originalDrag = rb.drag;
        rb.drag = temporaryDrag;
        yield return new WaitForSeconds(dragResetDelay);
        rb.drag = originalDrag;
    }
}