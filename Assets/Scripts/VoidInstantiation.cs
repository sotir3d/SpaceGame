using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidInstantiation : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject player;
    Quaternion q = Quaternion.identity;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(other.transform.parent.gameObject);
            Instantiate(player, spawnPoints[Random.Range(0, 3)].transform.position, q);
            StartCoroutine(PlayerMovement.DeathFeedback());
        }

        if(other.CompareTag("Block"))
        {
            Destroy(other.gameObject);   
            
        }
    }
}
