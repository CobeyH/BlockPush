using UnityEngine;

public class HazardDetection : MonoBehaviour
{
    GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Hazard"))
        {
            gameController.GameOver();
        }
    }
}
