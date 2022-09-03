using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    // Cache the base color so you know what color you should return to eventually.
    Renderer rend;
    Color baseColor;
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        baseColor = rend.material.color;
    }
    // Update is called once per frame
    void Update()
    {
        if (Powerup.isPowerOn())
        {
            rend.material.color = Powerup.LerpColor(baseColor);
        }
    }
}
