using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float torque = 50f;
    public float drag = 0.2f;

    private Rigidbody rb;
    private Transform playerCam; // Reference to Player Camera (not Camera.main)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag;

        // Cache reference to the actual "Player Camera"
        GameObject camObj = GameObject.Find("Player Camera");
        if (camObj != null)
        {
            playerCam = camObj.transform;
        }
        else
        {
            Debug.LogError("Player Camera not found. Make sure the camera is named exactly 'Player Camera'.");
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (playerCam == null) return;

        // Always use Player Camera's transform, regardless of which camera is active
        Vector3 inputDir = playerCam.forward * moveVertical + playerCam.right * moveHorizontal;
        inputDir.y = 0;
        inputDir.Normalize();

        rb.AddForce(inputDir * speed, ForceMode.Force);
        rb.AddTorque(new Vector3(0, moveHorizontal * torque, 0));
    }
}