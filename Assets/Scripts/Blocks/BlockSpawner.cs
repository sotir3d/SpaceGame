using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;

    public float spawnRate = 0.3f;
    public float blockSpawnPitchchangeRate;
    float lastBlockSpawn;
    GameObject newBlock;
    Vector2 newPosition;

    void Start()
    {
        InvokeRepeating("SpawnBlock", spawnRate, spawnRate);
    }

    public void SpawnBlock()
    {
        newBlock = Instantiate(block, new Vector2(Random.Range(-12.5f, 12.5f), Random.Range(-6f, 6f)), Quaternion.identity);
        newBlock.GetComponent<BlockHandler>().blockSpawner = gameObject;
        if ((Time.time - lastBlockSpawn)> blockSpawnPitchchangeRate)
        {
            FindObjectOfType<AudioManager>().Play("BlockPop");
            FindObjectOfType<AudioManager>().PitchShift("BlockPop", 0.7f, 1);
            lastBlockSpawn = Time.time;
        }
    }
}
