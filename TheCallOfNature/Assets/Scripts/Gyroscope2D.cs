using UnityEngine;
using UnityEngine.InputSystem;

public class Gyroscope2D : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float horizontalInput, verticalInput;

    [SerializeField] private float horizontalSpeed = 3f; // Adjustable in the Inspector
    [SerializeField] private float verticalSpeed = 10f; // Adjustable in the Inspector

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        if (UnityEngine.InputSystem.Gyroscope.current != null)
            InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
        if (UnityEngine.InputSystem.Accelerometer.current != null)
            InputSystem.EnableDevice(Accelerometer.current);
    }

    void Update()
    {
        // Get horizontal acceleration input without inverting direction
        horizontalInput = Accelerometer.current.acceleration.ReadValue().x * horizontalSpeed;
        verticalInput = Accelerometer.current.acceleration.ReadValue().y * verticalSpeed;
    }

    void FixedUpdate()
    {
        // Update Rigidbody2D velocity based on input
        rigidBody2D.linearVelocityX = horizontalInput;
        rigidBody2D.linearVelocityY = verticalInput;
    }
}