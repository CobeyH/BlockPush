using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public int speedModifier = 5;

    // Update is called once per frame
    void Update()
    {
        Vector3 positionOffset = new Vector3(0, 0, speedModifier * Time.deltaTime);
        gameObject.transform.position += positionOffset;
    }
}
