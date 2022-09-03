using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject chunkPrefab;

    [SerializeField]
    private GameObject endChunk;

    [SerializeField]
    private GameObject checkpoint;

    [SerializeField]
    private int CheckpointInterval = 2;

    public int levelSize = 1;

    // The game is rendered in chunks. Each chunk is 10 x 10 and will contain objects on it. A checkpoint may exist after each chunk.
    void Start()
    {
        Vector3 position = new Vector3(0, -0.75f, 0);
        // Build X chunks where X equals the level size.
        for (int i = 1; i < levelSize + 1; i++)
        {
            position = BuildTile(chunkPrefab, position);
            // Add a checkpoint between each X chunks where X is the checkpoint interval.
            if (i % CheckpointInterval == 0)
            {
                position = BuildTile(checkpoint, position);
            }
        }
        // Add the end chunk with the goal.
        BuildTile(endChunk, position);
    }

    // Take a prefab and update the position so that they generate connected in a straight line.
    Vector3 BuildTile(GameObject tile, Vector3 origin)
    {
        float tileLength = tile.transform.localScale.z;
        origin.z += tileLength / 2f;
        Instantiate(tile, origin, Quaternion.identity);
        origin.z += tileLength / 2f;
        return origin;
    }
}
