using UnityEngine;

public class Gyroscope2D : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float horizontalInput, verticalInput;

    [SerializeField] private float horizontalSpeed = 3f; // Adjustable in the Inspector
    [SerializeField] private float verticalSpeed = 10f; // Adjustable in the Inspector

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal acceleration input without inverting direction
        horizontalInput = Input.acceleration.x * horizontalSpeed;
        verticalInput = Input.acceleration.y * verticalSpeed;
    }

    void FixedUpdate()
    {
        // Update Rigidbody2D velocity based on input
        rigidBody2D.linearVelocityX = horizontalInput;
        rigidBody2D.linearVelocityY = verticalInput;
    }
}