﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    static SpriteRenderer sprtRend;
    static WaitForSeconds waitForSeconds = new WaitForSeconds(0.05f);

    Rigidbody2D playerRigidbody;
    Vector2 direction;
    Quaternion playerRotation;
    float angle;
    float horizontalInput;
    float verticalInput;

    void Start()
    {
        
        playerRotation = transform.rotation;
        playerRigidbody = GetComponent<Rigidbody2D>();
        sprtRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //ignores input when game is paused
        if (Time.timeScale == 0)
            return;

        playerRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * moveSpeed;

        //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //playerRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = playerRotation;

        if(Input.GetAxis("Turn") != 0)
        {
            transform.Rotate(Vector3.forward * Input.GetAxis("Turn"));
        }
    }

    public static IEnumerator DeathFeedback()
    {
        sprtRend.enabled = false;
        yield return waitForSeconds;
        sprtRend.enabled = true;
        yield return waitForSeconds;
        sprtRend.enabled = false;
        yield return waitForSeconds;
        sprtRend.enabled = true;
        yield return waitForSeconds;
        sprtRend.enabled = false;
        yield return waitForSeconds;
        sprtRend.enabled = true;
         yield return waitForSeconds;
        sprtRend.enabled = false;
        yield return waitForSeconds;
        sprtRend.enabled = true;
        yield return waitForSeconds;
        sprtRend.enabled = false;
        yield return waitForSeconds;
        sprtRend.enabled = true;
    }
}
