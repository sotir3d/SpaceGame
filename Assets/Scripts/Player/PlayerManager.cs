using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] spawnPoints;

    SpriteRenderer sprtRend;
    int numberOfSpawnpoints;

    void Start()
    {
        numberOfSpawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint").Length;
        sprtRend = GetComponent<SpriteRenderer>();
    }

    public IEnumerator DeathFeedback()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDead");
        int rng = Random.Range(0, numberOfSpawnpoints);
        gameObject.SetActive(false);
        transform.position = spawnPoints[rng].transform.position;
        transform.rotation = spawnPoints[rng].transform.rotation;
        gameObject.SetActive(true);

        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(0.05f);
            sprtRend.enabled = false;
            yield return new WaitForSeconds(0.05f);
            sprtRend.enabled = true;
        }
    }
}
