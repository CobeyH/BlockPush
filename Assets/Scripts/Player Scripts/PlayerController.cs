using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float drivingForce = 1000f;
    public float steeringForce = 500f;
    public InputAction movementControls;
    Rigidbody rigidBody;
    Vector2 moveDirection = Vector2.zero;

    void OnEnable()
    {
        movementControls.Enable();
    }

    void OnDisable()
    {
        movementControls.Disable();
    }

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
}
