using UnityEngine;

public class PointCollection : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Points"))
        {
            ScoreManager.score++;
            Destroy(collider.gameObject);
        }
    }
}
