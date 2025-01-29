using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8;

    public bool isMouse = true;
    private Rigidbody2D rb;
    // public AudioSource backgroundMusicSource;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // play background music 
        // if (backgroundMusicSource != null) {
        //     backgroundMusicSource.loop = true;
        //     backgroundMusicSource.Play();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement() 
    {
        Vector3 moveInput = Vector2.zero;
        Vector3 moveDirection = Vector3.zero;

        if (isMouse) 
        {
            // mouse uses WASD
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                moveInput.x = -1;
                moveDirection = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                moveInput.x = 1;
                moveDirection = Vector3.right;
            }
            else moveInput.x = 0;

            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                moveInput.y = 1;
                moveDirection = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                moveInput.y = -1;
                moveDirection = Vector3.down;
            }
            else moveInput.y = 0;
        }
        else 
        {
            // cat uses Arrow Keys
            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                moveInput.x = -1;
                moveDirection = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                moveInput.x = 1;
                moveDirection = Vector3.right;
            }
            else moveInput.x = 0;

            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            {
                moveInput.y = 1;
                moveDirection = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow))
            {
                moveInput.y = -1;
                moveDirection = Vector3.down;
            }
            else moveInput.y = 0;
        }

        // rotate the sprite to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f; // -90 since sprites face up to start
            
            float smoothAngle = Mathf.LerpAngle(transform.eulerAngles.z, angle, Time.deltaTime * 10f); 
            
            transform.rotation = Quaternion.Euler(0, 0, smoothAngle);
        }
        // move sprite
        rb.velocity = moveInput.normalized * moveSpeed;
    }
}
