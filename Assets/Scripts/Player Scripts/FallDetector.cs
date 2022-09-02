using UnityEngine;

public class FallDetector : MonoBehaviour
{
    // Check if the player has gone out of bounds
    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            // I know that you shouldn't put a find inside an update because it is slow.
            // However, it's fine here because it will only trigger once
            // when the above condition is true, not on every update.
            FindObjectOfType<GameController>().GameOver();
        }
    }
}
