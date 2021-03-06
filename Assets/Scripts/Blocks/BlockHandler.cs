﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public GameObject blockSpawner;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Vector2 newScale;
    Vector2 newPosition;
    bool isDestroyed = false;
    float spawnTime;

    float lerpSpeed = 0.1f;

    bool isDying = false;

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.CurrentBlocks++;

        newScale.x = 0;
        newScale.y = 0;
        transform.localScale = newScale;
        spawnTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        spriteRenderer.sprite = sprites[Random.Range(0, 10)];
        Invoke("EnableSpriteRenderer", 0.1f);

        StartCoroutine(InitialSizeLerp());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Avoids spawning blocks too near to the player, spawns a new block at a new location if it happens
        if (collision.CompareTag("PlayerCircle") && (Time.time - spawnTime) < 0.02f && !isDestroyed)
        {
            isDestroyed = true;
            blockSpawner.GetComponent<BlockSpawner>().SpawnBlock();
            Destroy(gameObject);
        }
    }

    void EnableSpriteRenderer()
    {
        spriteRenderer.enabled = true;
    }

    public IEnumerator Death(Vector2 voidPosition)
    {
        //avoids calling Death multiple times because of OnTriggerEnter2D weirdness
        if (!isDying)
        {
            Vector2 newPosition;

            FindObjectOfType<AudioManager>().Play("succ");

            gameManager.CurrentBlocks--;
            gameManager.DeliveredBlocks++;

            isDying = true;

            newPosition = transform.position;

            for (int i = 0; i <= 20; i++)
            {
                transform.Rotate(Vector3.forward * 30);

                newScale.x = Mathf.Lerp(newScale.x, 0, lerpSpeed);
                newScale.y = Mathf.Lerp(newScale.y, 0, lerpSpeed);
                transform.localScale = newScale;

                newPosition.x = Mathf.Lerp(newPosition.x, voidPosition.x, lerpSpeed);
                newPosition.y = Mathf.Lerp(newPosition.y, voidPosition.y, lerpSpeed);
                transform.position = newPosition;

                yield return new WaitForSeconds(0.03f);
            }

            Destroy(gameObject);
        }

    }

    IEnumerator InitialSizeLerp()
    {
        for (int i = 0; i <= 20; i++)
        {
            newScale.x = Mathf.Lerp(newScale.x, 1, lerpSpeed);
            newScale.y = Mathf.Lerp(newScale.y, 1, lerpSpeed);
            transform.localScale = newScale;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
