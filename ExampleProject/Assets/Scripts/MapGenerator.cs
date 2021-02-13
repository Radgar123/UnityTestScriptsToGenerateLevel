using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Main Atributes")]
    public GameObject player;
    public GameObject gameTerrain;
    public List<AudioSource> audio;

    [Header("Generate Items")]
    public int numberOfItems = 10;
    public List<GameObject> spwawnPool;


    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrainObject();
    }

    public void SpawnTerrainObject() 
    {
        int randomItem = 0;

        GameObject itemToSpawn;
        MeshCollider colider = gameTerrain.GetComponent<MeshCollider>();

        randomItem = Random.Range(0, audio.Count);

        Vector3 position;

        float x, y, z;

        for (int i = 0; i < numberOfItems; i++)
        {
            if (i == 1)
                itemToSpawn = player;
            else 
            {
                randomItem = Random.Range(0, spwawnPool.Count);
                itemToSpawn = spwawnPool[randomItem];
            }

            x = Random.Range(colider.bounds.min.x, colider.bounds.max.x);
            z = Random.Range(colider.bounds.min.z, colider.bounds.max.z);

            position = new Vector3(x, 0, z);

            Instantiate(itemToSpawn, position, Quaternion.identity);
        }
    }
}
