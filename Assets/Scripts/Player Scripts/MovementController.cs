using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float drivingForce = 1000f;

    [SerializeField]
    float steeringForce = 500f;

    [SerializeField]
    InputAction movementControls;
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
        rigidBody.AddForce(moveDirection.x * steeringForce, 0, moveDirection.y * drivingForce);
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
