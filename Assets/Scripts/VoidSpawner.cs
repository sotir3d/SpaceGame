using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidSpawner : MonoBehaviour
{
    public GameObject voidFloor;
    public int voidAmount = 15;

    Vector2 voidPos;
    int numberOfVoid;

    void Start()
    {
        InvokeRepeating("Spawn", 3, 5);
    }

    void Update()
    {
        voidPos = new Vector2(Random.Range(-12.5f, 12.5f), Random.Range(-6f, 6f));
    }

    void Spawn()
    {
        numberOfVoid = FindObjectsOfType<VoidHandler>().Length;
        if (numberOfVoid <= voidAmount)
            Instantiate(voidFloor, voidPos, Quaternion.identity);
    }
}
