using UnityEngine;

public class Gyroscope2D : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private float speed = 5f; // Adjustable in the Inspector

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal acceleration input without inverting direction
        horizontalInput = Input.acceleration.x * speed;
        verticalInput = Input.acceleration.y * speed;
    }

    void FixedUpdate()
    {
        // Update Rigidbody2D velocity based on input
        rigidBody2D.linearVelocityX = horizontalInput;
        rigidBody2D.linearVelocityY = verticalInput;
    }
}