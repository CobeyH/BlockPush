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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

}
