using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;
    public GameObject player;

    GameObject newBlock;

    float spawnTime = 2f;
    float lastSpawned = 0;
    Quaternion q;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - lastSpawned) > spawnTime)
        {
            newBlock = Instantiate(block, new Vector2(Random.Range(-9f, 9f), Random.Range(-5f, 5f)), q);

            //if ((newBlock.transform.position.x - player.transform.position.x) < 1)
            //{
            //    newBlock.transform.position.x += 1;
            //}
            lastSpawned = Time.time;
        }
    }
}
