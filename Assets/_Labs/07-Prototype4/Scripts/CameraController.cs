using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public float smoothSpeed = 5f;
    public float rotationSpeed = 100f;
    public float clipBuffer = 0.3f; // distance from wall to stop the camera

    private Vector3 offset;
    private float currentAngle = 0f;

    void Start()
    {
        offset = transform.position - Player.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // Calculate rotation based on input
        currentAngle += horizontal * rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);

        // Desired camera position
        Vector3 desiredPosition = Player.position + rotation * offset;

        // Raycast to detect obstacles
        RaycastHit hit;
        Vector3 direction = (desiredPosition - Player.position).normalized;
        float distance = offset.magnitude;

        Vector3 finalPosition = desiredPosition;

        if (Physics.Raycast(Player.position, direction, out hit, distance))
        {
            // Adjust camera to avoid clipping into obstacle
            finalPosition = hit.point - direction * clipBuffer;
        }

        // Smooth camera movement
        transform.position = Vector3.Lerp(transform.position, finalPosition, smoothSpeed * Time.deltaTime);

        // Make the camera look at the player
        transform.LookAt(Player);
    }
}