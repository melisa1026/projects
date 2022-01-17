// notes
// every jump currently goes down 13y...
// test if same results are obtained without the 
// maybe redo the jump funtion to be with the walk/run function, then just add a y shift


using UnityEngine;

public class playerControls2 : MonoBehaviour
{
    public Vector3 walkingSpeed;
    public Vector3 runningSpeed;

    private Vector3 playerSpot;
    private Vector3 mouseSpot;

    private bool isOnPlatform;
    private bool isJumping = false;
    private int jumpCount = 1;        // kinda like for loop but over update functions to count how far up and down player is going
    private bool jumpDir = true;      // if player is moving right (true) or left (false)
    private bool jumpUpDown = true;   // jumping up (true) or down (false)
    public float startGravity;
    private float gravity;

    


    // where the platforms are, formatted (height, right edge, left edge)
    public Vector3 platform1, platform2, platform3;

    private void Start()
    {
        gravity = startGravity;
    }
    public void Update()
    {
        mouseSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerSpot = transform.position;

        // if the player is jumping
        if (isJumping)
        {
            if (jumpCount == 0)
            {
                jumpCount = 1;
                isJumping = false;
                jumpUpDown = true;
                gravity = startGravity;
            }

            // jumping up
            else if (jumpUpDown == true)
            {
                // right
                if (jumpDir == true)
                {
                    gravity /= 1.2f;
                    transform.Translate(0.15f, gravity, 0);
                }
                // left
                else
                {
                    gravity /= 1.2f;
                    transform.Translate(-0.15f, gravity, 0);
                }
                jumpCount++;

                if (jumpCount == 30)
                    jumpUpDown = false;
            }

            // jumping down
            else
            {
                // right
                if (jumpDir == true)
                {
                    gravity *= 1.2f;
                    if (checkForPlatform(new Vector3(0.15f, -1 * gravity, 0)))
                        jumpCount = 0;
                    else
                        transform.Translate(0.15f, -1 * gravity, 0);
                }
                // left
                else
                {
                    gravity *= 1.2f;
                    if (checkForPlatform(new Vector3(-0.15f, -1 * gravity, 0)))
                        jumpCount = 0;
                    else
                        transform.Translate(-0.15f, -1 * gravity, 0);
                }
            }
        }
        // if mouse is clicked
        else if (Input.GetMouseButton(0))
        {
            // if mouse is higher than player
            if (mouseSpot.y > playerSpot.y + 3.0f)
            {
                isJumping = true;
                // jump right
                if (mouseSpot.x > playerSpot.x)
                {
                    jumpDir = true;
                }
                // jump left
                else
                {
                    jumpDir = false;
                }
            }

            // if mouse is lower than player
            else if (mouseSpot.y < playerSpot.y - 0.25f) // this should be in walk but just change the animation
            {
                // crouch
            }

            // if mouse is leveled with player
            else
            {
                // run right
                if (mouseSpot.x > playerSpot.x + 3f)
                {
                    transform.Translate(runningSpeed, Space.World);
                }
                // walk right
                else if (mouseSpot.x > playerSpot.x)
                {
                    transform.Translate(walkingSpeed, Space.World);
                }
                // run left
                else if (mouseSpot.x < playerSpot.x - 3.5f)
                {
                    transform.Translate(runningSpeed * -1, Space.World);
                }
                // walk left
                else if (mouseSpot.x < playerSpot.x - 2f)
                {
                    transform.Translate(walkingSpeed * -1, Space.World);
                }
            }
        }
    }

    // check if the character stepped off the platform
    public bool checkIfOffPlatform()
    {

        return true;
    }

    public bool checkForPlatform(Vector3 nextFallSpot)
    {
        // platform format: x1, x2, y

        // if the current update function will send the player under the platform, just put them on the platform and end the jump

        // nextFallSpot.x += transform.position.x;
        // nextFallSpot.y += transform.position.y;

        // verify this. It must go in if at some point of INFINITE LOOP
        if (nextFallSpot.x > platform1.x && nextFallSpot.x < platform1.y && nextFallSpot.y <= platform1.z && nextFallSpot.y > platform1.z - 0.5)
            return true;
        else if (nextFallSpot.x > platform2.x && nextFallSpot.x < platform2.y && nextFallSpot.y <= platform2.z && nextFallSpot.y > platform2.z - 0.5)
            return true;
        else
            return false;
    }

    public void FallToPlatform()
    {
        jumpCount = 1;
        isJumping = false;
        jumpUpDown = true;
        gravity = startGravity;
    }

}


/*
    moving character with mouse: how I will attempt it'
    
    if(mouse is clicked) move towards the x direction of the mouse
        if(mouse at closer distance) 
            walk + y dir change
        if(mouse at farther distance)
            run + x dir change

    if(character is on the ground and mouse points up)
        if(mouse it a bit up)
            small jump + y dir change
        if( mouse is far up)
            big spin jump + y dir change


    jumping: create public platforms with height, left and right dimentions. When player is on a platform, check if they have gotten off the platform

 */