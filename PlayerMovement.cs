using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;

    public AudioSource coinAudioSource;

    //to keep our rigid body
    Rigidbody rb;
    //flag to keep track of whether a jump started
    bool pressedJump = false;
    // Use this for initialization
    void Start()
    {
        //get the rigid body component for later use
        rb = GetComponent<Rigidbody>();
        coinAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        // Handle player walking
        WalkHandler();
        //Handle player jumping
        JumpHandler();
    }
    // Make the player walk according to user input
    void WalkHandler()
    {
        // Set x and z velocities to zero
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        // Distance ( speed = distance / time --> distance = speed * time)
        float distance = walkSpeed * Time.deltaTime;
        // Input on x ("Horizontal")
        float hAxis = Input.GetAxis("Horizontal");
        // Input on z ("Vertical")
        float vAxis = Input.GetAxis("Vertical");
        // Movement vector
        Vector3 movement = new Vector3(hAxis * distance, 0f, vAxis * distance);
        // Current position
        Vector3 currPosition = transform.position;
        // New position
        Vector3 newPosition = currPosition + movement;
        // Move the rigid body
        rb.MovePosition(newPosition);
    }
    // Check whether the player can jump and make it jump
    void JumpHandler()
    {
        // Check if the player is pressing the jump key
        if (Input.GetKey("space"))
        {
            // Make sure we've not already jumped on this key press
            if (!pressedJump)
            {
                // We are jumping on the current key press
                pressedJump = true;
                // Jumping vector
                Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);
                // Make the player jump by adding velocity
                rb.velocity = rb.velocity + jumpVector;
            }
        }
        else
        {
            if (rb.velocity.y > 0 && rb.velocity.y < 0.03)
            {
                pressedJump = false;
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        // Check if we ran into a coin
        if (collider.gameObject.tag == "Coin")
        {
            print("Grabbing coin..");
            // play sound
            coinAudioSource.Play();
            // increment score
            GameManager.instance.increaseScore(1);
            // Destroy coin
            Destroy(collider.gameObject);
        }
    }
}
