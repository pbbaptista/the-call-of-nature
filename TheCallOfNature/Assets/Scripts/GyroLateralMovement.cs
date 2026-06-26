using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class GyroLateralMovement : MonoBehaviour
    {
        public float forwardSpeed = 5f;
        public float horizontalSensitivity = 3f;
        public float verticalSensitivity = 3f;
        public float maxHorizontalOffset = 4f;
        public float maxVerticalOffset = 3f;

        private UnityEngine.InputSystem.Gyroscope gyro;
        private float horizontalOffset, verticalOffset;
        private Vector3 startPos;

        void OnEnable()
        {
            gyro = UnityEngine.InputSystem.Gyroscope.current;
            if (gyro != null)
                InputSystem.EnableDevice(gyro);
            startPos = transform.position;
        }

        void OnDisable()
        {
            if (gyro != null)
                InputSystem.DisableDevice(gyro);
        }

        void Update()
        {
            startPos += transform.forward * forwardSpeed * Time.deltaTime;

            if (gyro == null)
            {
                transform.position = startPos;
                return;
            }

            Vector3 angularVelocity = gyro.angularVelocity.ReadValue();

            horizontalOffset = Mathf.Clamp(horizontalOffset + angularVelocity.y * horizontalSensitivity * Time.deltaTime,
                                            -maxHorizontalOffset, maxHorizontalOffset);
            verticalOffset = Mathf.Clamp(verticalOffset - angularVelocity.x * verticalSensitivity * Time.deltaTime,
                                          -maxVerticalOffset, maxVerticalOffset);

            Vector3 offset = transform.right * horizontalOffset + transform.up * verticalOffset;
            transform.position = startPos + offset;
        }

        // expose for the tutorial tracker
        public float NormalizedHorizontal => horizontalOffset / maxHorizontalOffset;
        public float NormalizedVertical => verticalOffset / maxVerticalOffset;
    }
}
