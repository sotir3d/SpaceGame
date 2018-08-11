using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidInstantiation : MonoBehaviour
{
    public GameObject[] spawnPoints;
    Quaternion q = Quaternion.identity;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.position = spawnPoints[Random.Range(0, 3)].transform.position;
            other.gameObject.SetActive(true);
            StartCoroutine(PlayerMovement.DeathFeedback());
        }

        if(other.CompareTag("Block"))
        {
            Destroy(other.gameObject);   
            
        }
    }
}
