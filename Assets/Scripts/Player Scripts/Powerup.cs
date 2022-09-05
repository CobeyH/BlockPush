using UnityEngine;

public class Powerup : MonoBehaviour
{
    [HideInInspector]
    public static float remainingDuration;
    public static float powerDuration = 10;
    AudioManager audioManager;
    public static Color playerColor;
    // Start is called before the first frame update
    void Start()
    {
        remainingDuration = 0;
        playerColor = gameObject.GetComponent<Renderer>().material.color;
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (remainingDuration > 0)
        {
            remainingDuration = Mathf.Max(remainingDuration - Time.deltaTime, 0f);
        }

    }

    public static bool isPowerOn()
    {
        return remainingDuration > 0;
    }

    // Detect when player picks up a power up
    void OnTriggerEnter(Collider collider)
    {
        // If the player collides with a powerup.
        if (collider.gameObject.CompareTag("Powerup"))
        {
            remainingDuration = powerDuration;
            audioManager.Play("Power Up");
            Destroy(collider.gameObject);
        }
    }

    // Returns the color the object should be given the current state of the powerup
    public static Color LerpColor(Color endColor)
    {
        // If there is no powerup on, then return the objects own colour
        if (remainingDuration <= 0)
        {
            return endColor;
        }
        float t = (powerDuration - remainingDuration) / powerDuration;
        return Color.Lerp(playerColor, endColor, t);
    }
}
