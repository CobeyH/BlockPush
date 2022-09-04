using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField]
    float rotationSpeed = 10;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0, Space.World);
    }
}
