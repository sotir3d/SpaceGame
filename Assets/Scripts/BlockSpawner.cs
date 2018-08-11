using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;

    GameObject newBlock;
    Vector2 newPosition;

    void Start()
    {
        InvokeRepeating("SpawnBlock", 1f, 1f);
    }

    public void SpawnBlock()
    {
        newBlock = Instantiate(block, new Vector2(Random.Range(-12.5f, 12.5f), Random.Range(-6f, 6f)), Quaternion.identity);
        newBlock.GetComponent<BlockInstantiation>().blockSpawner = gameObject;
    }

}
