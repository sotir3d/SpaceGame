using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    public GameObject player;

    GameObject newBlock;
    Vector2 newPosition;
    Quaternion q = Quaternion.identity;

    void Start()
    {
        InvokeRepeating("SpawnBlock", 1f, 1f);
    }

    public void SpawnBlock()
    {
        newBlock = Instantiate(block, new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-5f, 5f)), q);
        newBlock.GetComponent<BlockInstantiation>().blockSpawner = gameObject;
    }
}
