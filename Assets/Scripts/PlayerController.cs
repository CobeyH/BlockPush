using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float drivingForce = 1000f;
    public float steeringForce = 500f;
    Rigidbody rigidBody;
    Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // I could use Unity's input system 1.02. However in this game the actions the player
        // can take are very limited. Thus, this solution is simpler.
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(moveDirection.x * steeringForce, 0, moveDirection.y * drivingForce);
    }
}
