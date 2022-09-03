using UnityEngine;

public class LaserDestruction : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    int trailDistance = -5;
    void Start()
    {
        // Caching the main camera because the main camera function is really slow.
        cam = Camera.main;
    }

    // The laser should always stay slightly ahead of the camera.
    void Update()
    {
        gameObject.transform.position = new Vector3(0, 0, cam.transform.position.z - trailDistance);
    }
    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
    }
}
