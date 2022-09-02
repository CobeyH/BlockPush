using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public TMP_Text scoreDisplay;

    // Update the score display
    void Update()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }
}
