using UnityEngine;

public class Powerup : MonoBehaviour
{
    [HideInInspector]
    public static float remainingDuration;
    [SerializeField]
    float powerDuration = 10;
    // Start is called before the first frame update
    void Start()
    {
        remainingDuration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingDuration > 0)
        {
            remainingDuration = Mathf.Max(remainingDuration - Time.deltaTime, 0f);
            Debug.Log(remainingDuration);
        }

    }

    public static bool isPowerOn()
    {
        return remainingDuration > 0;
    }
    void OnTriggerEnter(Collider collider)
    {
        // If the player collides with a powerup.
        if (collider.gameObject.CompareTag("Powerup"))
        {
            remainingDuration = powerDuration;
            Debug.Log(remainingDuration + " Other: " + powerDuration);
            Destroy(collider.gameObject);
        }
    }
}
