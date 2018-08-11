using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiation : MonoBehaviour
{
    public GameObject blockSpawner;

    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Vector2 newScale;
    Vector2 newPosition;
    bool isDestroyed = false;
    float spawnTime;

    void Start()
    {
        newScale.x = 0;
        newScale.y = 0;
        transform.localScale = newScale;
        spawnTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        spriteRenderer.sprite = sprites[Random.Range(0, 11)];
        Invoke("EnableSpriteRenderer", 0.1f);
    }

    void Update()
    {
        newScale.x = Mathf.Lerp(newScale.x, 1, 0.1f);
        newScale.y = Mathf.Lerp(newScale.y, 1, 0.1f);
        
        transform.localScale = newScale;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerCircle") && (Time.time - spawnTime) < 0.02f && !isDestroyed)
        {
            Debug.Log("destroyed");
            isDestroyed = true;
            blockSpawner.GetComponent<BlockSpawner>().SpawnBlock();
            Destroy(gameObject);
        }
    }

    void EnableSpriteRenderer()
    {
        spriteRenderer.enabled = true;
    }
}
