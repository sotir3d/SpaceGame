using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidSpawner : MonoBehaviour
{
    public GameObject voidFloor;
    public int voidAmount = 15;

    Vector2 voidPos;
    IList<GameObject> numberOfVoid;

    void Start()
    {
        numberOfVoid = new List<GameObject>();
        InvokeRepeating("Spawn", 3, 5);
    }

    void Update()
    {
        voidPos = new Vector2(Random.Range(-12.5f, 12.5f), Random.Range(-6f, 6f));

        if (numberOfVoid.Count > voidAmount)
        {
            Destroy();
        }
            
    }

    void Spawn()
    {
        if (numberOfVoid.Count <= voidAmount)
        {
            FindObjectOfType<AudioManager>().Play("VoidSpawn");
            GameObject voidFloorClone = Instantiate(voidFloor, voidPos, Quaternion.identity);
            numberOfVoid.Add(voidFloorClone);
        }       
    }

    void Destroy()
    {
        numberOfVoid[0].GetComponent<VoidHandler>().StartCoroutine("Disappear");
        numberOfVoid.RemoveAt(0);
    }
}
