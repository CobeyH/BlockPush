using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public static int speedModifier = 3;

    [SerializeField]
    int startSpeed = 3;
    [SerializeField]
    float trailingModifier = 0.3f;

    [SerializeField]
    GameObject player;

    void Start()
    {
        speedModifier = startSpeed;
    }

    // Move the camera based on either its speed or the distance to the player.
    void Update()
    {
        float offsetFactor = CalculatePositionOffset();
        Vector3 positionOffset = new Vector3(0, 0, offsetFactor);
        gameObject.transform.position += positionOffset;
    }

    // Calculates how far the camera should move along the Z-Axis.
    // If the player is far ahead of the camera, the camera will speed up in order to catch up.
    float CalculatePositionOffset()
    {
        float distanceFactor = DistanceToPlayer() * trailingModifier * Time.deltaTime;
        float speedFactor = speedModifier * Time.deltaTime;
        return Mathf.Max(distanceFactor, speedFactor);
    }

    // Calculates the distance from the camera to the player along the Z-axis
    float DistanceToPlayer()
    {
        float camPosZ = gameObject.transform.position.z;
        float playerPosZ = player.transform.position.z;

        return playerPosZ - camPosZ;
    }
}
