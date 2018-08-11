using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    //public GameObject feet;
    //public AudioClip footstepSound;

    Vector2 direction;
    Quaternion playerRotation;
    Rigidbody2D playerRigidbody;

    //Animator anim;
    //Animator feetAnim;

    //AudioSource playerAudioSource;

    float angle;
    float horizontalInput;
    float verticalInput;

    // Use this for initialization
    void Start()
    {
        playerRotation = transform.rotation;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //ignores input when game is paused
        if (Time.timeScale == 0)
            return;

        playerRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * moveSpeed;

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        playerRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = playerRotation;
    }
}
