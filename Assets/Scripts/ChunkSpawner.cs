using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject chunkPrefab;

    [SerializeField]
    Texture2D[] maps;
    [SerializeField]
    ColorToPrefab[] colorMappings;


    // The game is rendered in chunks. Each chunk is 10 x 10 and will contain objects on it. A checkpoint may exist after each chunk.
    void Start()
    {
        Vector3 position = new Vector3(0, -0.75f, 0);
        // Build a chunk for each map in the array
        for (int i = 0; i < maps.Length; i++)
        {
            // The build position will be set to the center of the tile.
            position += new Vector3(0, 0, maps[i].height / 2);
            BuildTile(maps[i], position);
            position += new Vector3(0, 0, maps[i].height / 2);
        }
    }

    // Take a prefab and update the position so that they generate connected in a straight line.
    void BuildTile(Texture2D map, Vector3 position)
    {
        // Build ground from the center
        GameObject groundTile = Instantiate(chunkPrefab, position, Quaternion.identity);
        groundTile.transform.localScale = new Vector3(map.width, 0.5f, map.height);

        // Set origin to the bottom left
        position += new Vector3(-map.width / 2, 0.75f, -map.height / 2);
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                Color pixel = map.GetPixel(x, z);
                Vector3 objPosition = new Vector3(position.x + x, position.y, position.z + z);
                GenerateObject(pixel, objPosition);
            }
        }
    }

    void GenerateObject(Color pixel, Vector3 drawPosition)
    {
        if (pixel.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color == pixel)
            {
                // Draw from the center of the 1 x 1 unit instead of the bottom left corner.
                drawPosition += new Vector3(0.5f, 0, 0.5f);
                Instantiate(colorMapping.prefab, drawPosition, colorMapping.prefab.transform.rotation);
            }
        }

    }

    public int GetLevelCount()
    {
        return maps.Length;
    }
}
