using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    /// <summary>
    /// Movement mode type
    /// </summary>
    public enum MovementMode
    {
        Kinematic,
        Physics
    }

    [Header("Mode")]
    [SerializeField] private MovementMode movementMode = MovementMode.Kinematic;

    /// <summary>
    /// Forward movement speed
    /// </summary>
    [Header("Movement")]
    [SerializeField] private float forwardSpeed = 20f;

    [Header("Kinematic Rotation")]
    [SerializeField] private float kinematicRotationSpeed = 100f;

    [Header("Physics Rotation")]
    [SerializeField] private float physicsTorque = 10f;

    private float pitchInput;
    private float yawInput;
    private float rollInput;

    private Rigidbody rb;
    private ShipBoost shipBoost;

    private void Awake()
    {
        // Get references
        rb = GetComponent<Rigidbody>();
        shipBoost = GetComponent<ShipBoost>();
    }

    private void Update()
    {
        HandleInput();

        // Debug: switch mode
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMode();
        }
    }

    private void FixedUpdate()
    {
        switch (movementMode)
        {
            case MovementMode.Kinematic:
                MoveKinematic();
                break;

            case MovementMode.Physics:
                MovePhysics();
                break;
        }
    }

    /// <summary>
    /// Reads player input (vertical, horizontal and roll)
    /// </summary>
    private void HandleInput()
    {
        pitchInput = -Input.GetAxis("Vertical");
        yawInput = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");
    }

    /// <summary>
    /// Kinematic movement
    /// </summary>
    private void MoveKinematic()
    {
        float multiplier = shipBoost != null ? shipBoost.CurrentMultiplier : 1f;

        // Forward
        transform.position += transform.forward * forwardSpeed * multiplier * Time.fixedDeltaTime;

        // Rotation
        Vector3 rotation = new Vector3(pitchInput, yawInput, rollInput) * kinematicRotationSpeed * Time.fixedDeltaTime;

        transform.Rotate(rotation, Space.Self);
    }

    /// <summary>
    /// Physics-based movement
    /// </summary>
    private void MovePhysics()
    {
        float multiplier = shipBoost != null ? shipBoost.CurrentMultiplier : 1f;

        // Forward force
        rb.AddForce(transform.forward * forwardSpeed * multiplier, ForceMode.Impulse);

        // Torque
        Vector3 direction = new Vector3(pitchInput, yawInput, -rollInput) * physicsTorque;
        rb.AddForce(direction, ForceMode.Force);
    }

    /// <summary>
    /// Switch between movement modes
    /// </summary>
    private void ToggleMode()
    {
        movementMode = movementMode == MovementMode.Kinematic ? MovementMode.Physics : MovementMode.Kinematic;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}