using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter()
    {
        CameraMovement.speedModifier += 1;
    }
}
