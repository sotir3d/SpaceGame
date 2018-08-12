using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidHandler : MonoBehaviour
{
    PlayerManager playerManager;
    Vector2 newScale;
    Vector2 newPosition;

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
    }
}
