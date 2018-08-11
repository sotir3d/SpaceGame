using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidAppear : MonoBehaviour
{
    public GameObject voidFloor;
    public GameObject[] spawnPoints;
    Vector2 voidPos;
    Quaternion q = Quaternion.identity;

    void Start()
    {
        voidPos = new Vector2(Random.Range(-9, 9), Random.Range(-5, 5));
        InvokeRepeating("Spawn", 5, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            spawnPoints[Random.Range(0, 4)].transform.position = other.transform.position;
            StartCoroutine(PlayerMovement.DeathFeedback());
            StartCoroutine(PlayerMovement.DeathFeedback());
        }

        if(other.CompareTag("Block"))
        {
            Destroy(other.gameObject);   
        }
    }

    void Spawn()
    {
        Instantiate(voidFloor, voidPos, q);
    }
}
