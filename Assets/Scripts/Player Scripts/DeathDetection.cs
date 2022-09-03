using UnityEngine;

public class DeathDetection : MonoBehaviour
{
    GameController gc;
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Check if the player has gone out of bounds
    void Update()
    {
        if (gameObject.transform.position.y < -1)
        {
            gc.GameOver();
        }
    }

    // When the player falls behind too much, destroy them
    void OnBecameInvisible()
    {
        gc.GameOver();
    }

    // Detection for Hazard Blocks
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Hazard"))
        {
            gc.GameOver();
        }
    }
}
