using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //ignores input when game is paused
        if (Time.timeScale == 0)
            return;

        playerRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * moveSpeed;

        if (Input.GetAxis("Turn") != 0)
        {
            transform.Rotate(Vector3.forward * Input.GetAxis("Turn"));
        }
    }
}
