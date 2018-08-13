using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float turnSpeed = 200f;
    public float footstepSoundSpeed;

    bool playOnce = false;
    float lastFootstepSound;
    Rigidbody2D playerRigidbody;

    void Start()
    {
        lastFootstepSound = Time.time;
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

        if (Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") !=0)
        {
            if ((Time.time - lastFootstepSound) > footstepSoundSpeed)
            {
                FindObjectOfType<AudioManager>().Play("FootstepSound");
                
                    FindObjectOfType<AudioManager>().PitchShift("FootstepSound", 0.8f, 1);
                
                lastFootstepSound = Time.time;
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("FootstepSound");
        }
    }
}