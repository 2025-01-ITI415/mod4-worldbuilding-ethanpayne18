using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;         // Force strength
    public float torque = 50f;        // Spin force
    public float drag = 0.2f;         // Light resistance to slow sliding

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag; // constant mild resistance
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Camera-relative movement
        Vector3 inputDir = Camera.main.transform.forward * moveVertical + Camera.main.transform.right * moveHorizontal;
        inputDir.y = 0;
        inputDir.Normalize();

        // Apply force for movement
        rb.AddForce(inputDir * speed, ForceMode.Force);

        // Spin ball for visual feedback
        rb.AddTorque(new Vector3(0, moveHorizontal * torque, 0));
    }
}