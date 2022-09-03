using UnityEngine;
using TMPro;

public class PowerupDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text displayText;
    Color baseColor;
    void Start()
    {
        // The basecolor will be used to restore the color if it changed.
        baseColor = displayText.color;
    }

    // Update is called once per frame
    void Update()
    {
        // The text should be enabled when the power is on, and disabled when it isn't
        if (Powerup.isPowerOn() != displayText.enabled)
        {
            displayText.enabled = !displayText.enabled;
        }
        // Display the text when the powerup is in effect and change its colour over time
        if (displayText.enabled)
        {
            float sanitizedTime = Mathf.Floor(Powerup.remainingDuration * 10) / 10f;
            displayText.text = sanitizedTime.ToString();
            displayText.color = Powerup.LerpColor(baseColor);
        }


    }
}
