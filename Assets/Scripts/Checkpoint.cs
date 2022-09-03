using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Detection for collision with a player
    void OnTriggerEnter(Collider collider)
    {
        // Make sure it collided with the player
        if (collider.gameObject.layer == 8)
        {
            CameraMovement.speedModifier += 1;
        }
    }
}
