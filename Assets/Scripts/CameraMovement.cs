using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public static int speedModifier = 3;

    [SerializeField]
    int startSpeed = 3;
    [SerializeField]
    float maxTrail = 15f;
    [SerializeField]
    GameObject player;

    void Start()
    {
        speedModifier = startSpeed;
    }

    // Move the camera based on either its speed or the distance to the player.
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        // Update camera position.
        float offsetFactor = CalculatePositionOffset();
        Vector3 positionOffset = new Vector3(0, 0, offsetFactor);
        gameObject.transform.position += positionOffset;
        // Update Lookup Vector
        Vector3 toLook = new Vector3(0, 0, player.transform.position.z + 5);
        gameObject.transform.LookAt(toLook);
    }

    // Calculates how far the camera should move along the Z-Axis.
    // If the player is far ahead of the camera, the camera will speed up in order to catch up.
    float CalculatePositionOffset()
    {
        float distToPlayer = DistanceToPlayer();
        if (distToPlayer > maxTrail)
        {
            return distToPlayer - maxTrail;
        }
        return speedModifier * Time.deltaTime;
    }

    // Calculates the distance from the camera to the player along the Z-axis
    float DistanceToPlayer()
    {
        float camPosZ = gameObject.transform.position.z;
        float playerPosZ = player.transform.position.z;

        return playerPosZ - camPosZ;
    }
}
