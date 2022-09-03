using UnityEngine;

public class PointCollection : MonoBehaviour
{
    // Detection for player collecting a point
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Points"))
        {
            ScoreManager.score++;
            Destroy(collider.gameObject);
        }
    }
}
