using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    public GameObject player;

    GameObject newBlock;
    Vector2 newPosition;

    Quaternion q;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnBlock", 1f, 1f);
    }

    public void SpawnBlock()
    {
        newBlock = Instantiate(block, new Vector2(Random.Range(-9f, 9f), Random.Range(-5f, 5f)), q);
        newBlock.GetComponent<BlockInstantiation>().blockSpawner = gameObject;
    }
}
