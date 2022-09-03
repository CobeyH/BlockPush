using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject chunkPrefab;
    public int levelSize = 1;

    // The game is rendered in chunks. Each chunk is 10 x 10 and will contain objects on it. A checkpoint may exist after each checkpoint.
    void Start()
    {
        for (int i = 0; i < levelSize; i++)
        {
            Vector3 position = new Vector3(0, -0.75f, chunkPrefab.transform.localScale.z * i);
            Instantiate(chunkPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
