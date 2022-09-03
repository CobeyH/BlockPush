using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    // Detection for Neutral Blocks
    void OnCollisionEnter(Collision collision)
    {
        // When the player hits a neutral object prevent the neutral object from moving.
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Detection for Neutral Blocks
    void OnCollisionExit(Collision collision)
    {
        // When the player stops colliding with a neutral object start normal motion.
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
