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
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        baseColor = rend.material.color;
        rb = gameObject.GetComponent<Rigidbody>();
        baseKinematic = rb.isKinematic;
    }
    // Update is called once per frame
    void Update()
    {
        if (Powerup.isPowerOn())
        {
            rend.material.color = Powerup.LerpColor(baseColor);
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = baseKinematic;
        }
    }
}
