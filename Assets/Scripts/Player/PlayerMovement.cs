using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float turnSpeed = 200f;

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

        if (Input.GetAxis("Turn") != 0)
        {
            transform.Rotate(Vector3.forward * Input.GetAxis("Turn") * turnSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }
}
