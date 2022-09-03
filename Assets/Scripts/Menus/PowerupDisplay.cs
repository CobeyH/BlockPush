using UnityEngine;
using TMPro;

public class PowerupDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text displayText;
    Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
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
        if (displayText.enabled)
        {
            float sanitizedTime = Mathf.Floor(Powerup.remainingDuration * 10) / 10f;
            displayText.text = sanitizedTime.ToString();
            displayText.color = Powerup.LerpColor(baseColor);
        }


    }
}
