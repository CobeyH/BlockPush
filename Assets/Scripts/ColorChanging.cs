using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    // Cache the base color so you know what color you should return to eventually.
    Renderer rend;
    Color baseColor;
    Rigidbody rb;
    bool baseKinematic;
    bool powerModeSwitched = false;
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        baseColor = rend.material.color;
        rb = gameObject.GetComponent<Rigidbody>();
        baseKinematic = rb.isKinematic;
    }
    void Update()
    {
        UpdateColor();
    }

    // Updates the color of the game object based on the state of the powerup.
    void UpdateColor()
    {
        // When the powerup is on. The color changes to the player's color. Then slowly reverts back to it's original color.
        if (Powerup.isPowerOn())
        {
            rend.material.color = Powerup.LerpColor(baseColor);
            // All objects should be moveable when powerup is enabled. Therefore the kinematic is disabled.
            rb.isKinematic = false;
            powerModeSwitched = true;
        }
        // Make sure that the kinematic property only gets set once to avoid issues with neutral objects.
        else if (powerModeSwitched)
        {
            rb.isKinematic = baseKinematic;
            powerModeSwitched = false;
        }
    }
}
