using UnityEngine;

public class LaserDestruction : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    GameController gm;
    int trailDistance = -5;
    void Start()
    {
        // Caching the main camera because the main camera function is really slow.
        cam = Camera.main;
        gm = FindObjectOfType<GameController>();
    }

    // The laser should always stay slightly ahead of the camera.
    void Update()
    {
        gameObject.transform.position = new Vector3(0, 0, cam.transform.position.z - trailDistance);
    }

    // When the laser hits an object, it destroys that object.
    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
        // Game is over if the player hits the laser
        if (collider.gameObject.layer == 8)
        {
            gm.LoseGame();
        }
    }
}
