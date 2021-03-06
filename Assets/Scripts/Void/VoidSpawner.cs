﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidSpawner : MonoBehaviour
{
    public GameObject voidFloor;
    public int voidAmount = 15;
    public int spawnRate = 5;
    
    Vector2 voidPos;
    IList<GameObject> numberOfVoid;

    void Start()
    {
        numberOfVoid = new List<GameObject>();
        InvokeRepeating("Spawn", 1, spawnRate);
    }

    void Update()
    {
        voidPos = new Vector2(Random.Range(-12.5f, 12.5f), Random.Range(-6f, 6f));

        if (numberOfVoid.Count > voidAmount)
        {
            Destroy();
        }
            
    }

    public void Spawn()
    {
        if (numberOfVoid.Count <= voidAmount)
        {
            FindObjectOfType<AudioManager>().Play("VoidSpawn");
            GameObject voidFloorClone = Instantiate(voidFloor, voidPos, Quaternion.identity);

            voidFloorClone.GetComponent<VoidHandler>().voidSpawner = gameObject;

            numberOfVoid.Add(voidFloorClone);
        }       
    }

    void Destroy()
    {
        numberOfVoid[0].GetComponent<VoidHandler>().StartCoroutine("Disappear");
        numberOfVoid.RemoveAt(0);
    }

    public void DestroyOnWrongLocation(GameObject removedVoid)
    {
        numberOfVoid.Remove(removedVoid);
        Destroy(removedVoid);
    }

}
