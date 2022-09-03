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
            gc.LoseGame();
        }
    }

    // Detection for Gameover conditions
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Hazard") && !Powerup.isPowerOn())
        {
            gc.LoseGame();
        }
        else if (collider.CompareTag("FinishLine"))
        {
            gc.WinGame();
        }
    }
}
