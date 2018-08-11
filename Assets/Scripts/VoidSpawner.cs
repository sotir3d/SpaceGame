using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidSpawner : MonoBehaviour
{
    public GameObject voidFloor;
    Vector2 voidPos;
    Quaternion q = Quaternion.identity;
    int numberOfVoid;

    void Start()
    {
        InvokeRepeating("Spawn", 5, 10);
    }

    void Update()
    {
        voidPos = new Vector2(Random.Range(-9, 9), Random.Range(-5, 5));
    }

    void Spawn()
    {
        numberOfVoid = FindObjectsOfType<VoidInstantiation>().Length;
        if (numberOfVoid <= 9)
            Instantiate(voidFloor, voidPos, q);

    }
}
