using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;          // default movement speed
    public float torque = 50f;         // rotation speed (higher = faster turning)
    public float stoppingDrag = 5f;    // Drag value to stop faster
    public float normalDrag = 0.5f;    // Normal drag when moving
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = normalDrag;  // Set normal drag at start
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get movement direction relative to camera
        Vector3 movement = Camera.main.transform.forward * moveVertical + Camera.main.transform.right * moveHorizontal;
        movement.y = 0; // Prevent unintended vertical movement
        movement.Normalize();

        // Apply force for movement
        rb.AddForce(movement * speed, ForceMode.Acceleration);

        // Apply torque for faster turning
        rb.AddTorque(new Vector3(0, moveHorizontal * torque, 0));

        // If no input is detected, increase drag to stop faster
        if (moveHorizontal == 0 && moveVertical == 0)
        {
            rb.drag = stoppingDrag;
        }
        else
        {
            rb.drag = normalDrag;
        }

    }
}