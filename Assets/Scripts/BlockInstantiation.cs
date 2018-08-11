using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiation : MonoBehaviour
{
    Vector2 newScale;

    Vector2 newPosition;
    // Use this for initialization
    void Start()
    {
        newScale.x = 0;
        newScale.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        newScale.x = Mathf.Lerp(newScale.x, 1, 0.1f);
        newScale.y = Mathf.Lerp(newScale.y, 1, 0.1f);
        
        transform.localScale = newScale;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("asf");
    //    if (collision.gameObject.CompareTag("PlayerCircle"))
    //    {
    //        Debug.Log("hier");
    //        newPosition = transform.position;
    //        newPosition.x += 4.5f;
    //        newPosition.y += 4.5f;
    //        transform.position = newPosition;
    //    }
    //}
}
