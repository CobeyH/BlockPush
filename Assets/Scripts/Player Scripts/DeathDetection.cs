using UnityEngine;

public class DeathDetection : MonoBehaviour
{
    GameController gc;
    DeathEffect death;
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        death = gameObject.GetComponent<DeathEffect>();
    }

    // Check if the player has gone out of bounds

    // Detection for Gameover conditions
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Hazard") && !Powerup.isPowerOn())
        {
            death.DestroyWithEffect();
        }
        else if (collider.CompareTag("FinishLine"))
        {
            gc.WinGame();
        }
    }
}
