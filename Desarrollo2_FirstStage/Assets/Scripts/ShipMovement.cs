using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // Movement parameters
    [Header("Movement")]
    [SerializeField] private float forwardSpeed = 20f;

    // Rotation parameters
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 20f;

    private float pitchInput;
    private float yawInput;
    private float rollInput;

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        MoveForward();
        HandleRotation();
    }

    /// <summary>
    /// Reads player input
    /// </summary>
    private void HandleInput()
    {
        pitchInput = -Input.GetAxis("Vertical");
        yawInput = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");  
    }

    /// <summary>
    /// Foorward movement
    /// </summary>
    private void MoveForward()
    {
        transform.position += transform.forward * forwardSpeed * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Ship Rotation movement
    /// </summary>
    private void HandleRotation()
    {
        Vector3 rotation = new Vector3(pitchInput, yawInput, rollInput) * rotationSpeed;
        transform.Rotate(rotation, Space.Self);
    }
}
