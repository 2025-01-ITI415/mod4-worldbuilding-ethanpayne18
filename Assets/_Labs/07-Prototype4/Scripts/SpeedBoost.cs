using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float boostAmount = 10f;
    public KeyCode boostKey = KeyCode.LeftShift;

    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("SpeedBoost requires PlayerController on the same GameObject.");
        }
    }

    void Update()
    {
        if (playerController == null) return;

        if (Input.GetKey(boostKey))
        {
            playerController.speed = baseSpeed + boostAmount;
        }
        else
        {
            playerController.speed = baseSpeed;
        }
    }
}