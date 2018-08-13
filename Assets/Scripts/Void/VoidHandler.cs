using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidHandler : MonoBehaviour
{
    PlayerManager playerManager;
    Vector2 newScale;
    float lerpSpeed = 20;

    void Start()
    {
        newScale.x = 0;
        newScale.y = 0;
        transform.localScale = newScale;
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void Update()
    {
        newScale.x = Mathf.Lerp(newScale.x, 1, 2f * Time.deltaTime);
        newScale.y = Mathf.Lerp(newScale.y, 1, 2f * Time.deltaTime);
        transform.localScale = newScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(playerManager.DeathFeedback());
        }

        if (other.CompareTag("Block"))
        {
            StartCoroutine(other.GetComponent<BlockHandler>().Death(transform.position));
        }

        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Disappear()
    {
        for (int i = 0; i <= 50; i++)
        {
            newScale.x = Mathf.Lerp(newScale.x, 0, lerpSpeed * Time.deltaTime);
            newScale.y = Mathf.Lerp(newScale.y, 0, lerpSpeed * Time.deltaTime);
            transform.localScale = newScale;
            yield return new WaitForSeconds(0.03f);
        }
        Destroy(gameObject);
    }
}
