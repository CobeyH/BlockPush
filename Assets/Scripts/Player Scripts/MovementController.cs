using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float drivingForce = 1000f;

    [SerializeField]
    float steeringForce = 500f;
    [SerializeField]
    float maxSpeed = 5f;

    [SerializeField]
    InputAction movementControls;

    [SerializeField]
    AnimationCurve accelerationCurve;
    Rigidbody rigidBody;
    Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // I used Unity's version 1.02 player input because it's easier to
        // support any keyboard layout. Since I use DVORAK keybord layout I didn't
        // want to bind controls to specific keys.
        moveDirection = movementControls.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        float xAcceleration = GetAccelerationProportion(moveDirection.x - rigidBody.velocity.x / maxSpeed);
        float zAcceleration = GetAccelerationProportion(moveDirection.y - rigidBody.velocity.z / maxSpeed);
        rigidBody.AddForce(xAcceleration * steeringForce, 0, zAcceleration * drivingForce);
    }

    float GetAccelerationProportion(float error)
    {
        return accelerationCurve.Evaluate(error);
    }

    // Set up player controls
    void OnEnable()
    {
        movementControls.Enable();
    }

    void OnDisable()
    {
        movementControls.Disable();
    }
}
