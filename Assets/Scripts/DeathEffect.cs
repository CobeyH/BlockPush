using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField]
    GameObject deathParticles;
    [SerializeField]
    Mesh particleMesh;
    GameController gc;
    AudioManager audioManager;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (gameObject.transform.position.y < -1)
        {
            DestroyWithEffect();
        }
    }

    public void DestroyWithEffect()
    {
        if (gameObject.CompareTag("Player"))
        {
            gc.LoseGame();
        }
        audioManager.Play("Destroy");
        Destroy(gameObject);
        GameObject particles = Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);
        // TODO: This will have horrible performance. Rework this to be more efficient.
        // I'm worrying more about getting features done first, then optimization later.
        ParticleSystem ps = particles.GetComponent<ParticleSystem>();
        ps.GetComponent<ParticleSystemRenderer>().mesh = particleMesh;
        ps.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        var sh = ps.shape;
        sh.mesh = particleMesh;
        Destroy(particles, 3);
    }
}
