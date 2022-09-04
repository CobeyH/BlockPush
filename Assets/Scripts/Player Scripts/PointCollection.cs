using UnityEngine;

public class PointCollection : MonoBehaviour
{
    AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    // Detection for player collecting a point
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Points"))
        {
            ScoreManager.score++;
            Destroy(collider.gameObject);
            audioManager.Play("Coin Pickup");
        }
    }
}
