// problem log
// walk speed isnt right


using UnityEngine;
using UnityEngine.SceneManagement;

public class innerMallPlayerControls : MonoBehaviour
{

    [Range(0f, 1f)] // play with the range
    public float walkSpeed = 0.12f, runSpeed = 0.43f;
    [Range(20, 100)]
    //how many frames will the character be going up for
    public int jumpUpFrames = 20;
    [Range(1.1f, 1.5f)]
    public float gravity = 0.7f;
    [Range(0, 3)]
    // how close must the mouse be for the characeter to be walking and how far from the character the mouse should be to work at all
    public float walkDist = 2, mouseMoveDist;
    // how much to move the player in X dir when mirrored / axis is too far right so subtract offset from position to get actual position
    [Range(-2, 2)]
    public float mirrorPivotOffset = -1.2f, xOffset, tropocicanGravitationalConstant;
    public float velocity = 0.8f;

    private Vector3 mirrorToRight = new Vector3(0, -180, 0), mirrorToLeft = new Vector3(0, 180, 0); // how much to rotate when mirrored
    private Vector3 mouseSpot;
    private bool isJumpingRight = false, isJumping = false, isLookingRight = true, isJumpingUp = true, isCrouching = false;
    private int jumpCount = 0;
    private Vector3 nextSpot;
    private float escalatorLocInThisY;
    private bool isGoingUp = false, isFallingStraight = false, spinJump = false;

    public Animator anim;

    public static bool mouseRight;     // global for use in cursor shape too

    public talk playerSpeechScript;


    private void Start()
    {
        
        if (staticVariables.pressedUseUselessObj)
        {
            playerSpeechScript.oneLine();
            staticVariables.pressedUseUselessObj = false;
        }

        transform.position = staticVariables.enterLocation;
        if (staticVariables.comeInRight)
        {
            isLookingRight = true;
            
        }
        else
        {
            transform.Rotate(0, 180, 0, Space.World); // look into rotate function
            isLookingRight = false;
        }
    }

    private void Update()
    {   // check the posiiton of the mouse
        mouseSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // if mouse button is down
        if ((Input.GetMouseButton(0) || isJumping) && !isGoingUp && !isFallingStraight)
        {
            // if already jumping 
            if (isJumping)
            {
                // is going upwards
                if (isJumpingUp)
                {
                    if (isJumpingRight)
                        transform.Translate(walkSpeed, velocity, 0, Space.World);
                    else
                    {
                        transform.Translate(-1 * walkSpeed, velocity, 0, Space.World);

                        // if character is doing a spin jump, spin 360 degrees in z while going up 
                        if (spinJump)
                        {
                            transform.Rotate(0, 0, 180 / jumpUpFrames, Space.World);
                        }
                    }
                }
                // is falling downwards
                else
                {

                    if (isJumpingRight)
                    {
                        // check if  the player is landing on the escalators
                        nextSpot = new Vector3(transform.position.x + (-1 * walkSpeed), transform.position.y + -1 * velocity, transform.position.z + 0);
                        escalatorLocInThisY = (transform.position.y + 10.5f) / 0.8964f;
                        if ((transform.position.x - 0.5) <= escalatorLocInThisY && (nextSpot.x + 0.5) >= escalatorLocInThisY)
                        {
                            transform.position = new Vector3(escalatorLocInThisY, transform.position.y, transform.position.z);
                            isJumping = false;
                            isJumpingUp = true;
                            anim.Play("stand");
                            isGoingUp = true;
                        }
                        else
                        {
                            transform.Translate(walkSpeed, -1 * velocity, 0, Space.World);
                        }
                    }
                    else
                    {
                        transform.Translate(-1 * walkSpeed, -1 * velocity, 0, Space.World);

                        // if character is doing a spin jump, spin 360 degrees in z while going down
                        if (spinJump)
                        {
                            transform.Rotate(0, 0, 180 / jumpUpFrames, Space.World);
                        }
                    }
                }
                jumpCount++;
                if (jumpCount < jumpUpFrames)
                    velocity /= tropocicanGravitationalConstant;
                else if (jumpCount == jumpUpFrames)
                {
                    jumpCount++;
                    isJumpingUp = false;
                }
                else if (jumpCount < 2 * jumpUpFrames + 1) // no else if. This is just here bc the end of the jump isnt implemented yet
                {
                    velocity *= tropocicanGravitationalConstant;
                    // if landed on platform (+ other stuff on pseudo here)
                }
                else // end of jump
                {
                    // if the character is on the second floor pas the railing, keep falling
                    if (transform.position.y > 3f && transform.position.x < -13.16)
                    {
                        isFallingStraight = true;
                        continueFalling();
                        isJumping = false;
                        isJumpingUp = true;
                        jumpCount = 0;
                    }
                    else
                    {
                        isJumping = false;
                        isJumpingUp = true;
                        jumpCount = 0;
                        anim.Play("stand");
                    }
                }
            }
            // if the mouse is on the right + a bit
            else if (mouseSpot.x > (transform.position.x - xOffset + mouseMoveDist))
            {
                // if mouse clicked right but facing left, switch to face right
                if (!isLookingRight)
                {
                    transform.Rotate(0, -180, 0, Space.World); // look into rotate function
                    isLookingRight = true;
                }

                // jumping starts (activate jumping)
                if (mouseSpot.y > (transform.position.y + 3.0f))
                {
                    isJumping = true;
                    isJumpingRight = true;
                    anim.Play("jump");
                }
                // walking speed
                else if ((mouseSpot.x - (transform.position.x - xOffset)) < walkDist)
                {
                    transform.Translate(walkSpeed, 0, 0, Space.World);
                    if (!isCrouching)
                        anim.Play("walk");
                }
                // running speed
                else
                {
                    transform.Translate(runSpeed, 0, 0, Space.World);
                    if (!isCrouching)
                        anim.Play("run");
                }

            }

            // if the mouse is on the left
            else if (mouseSpot.x < (transform.position.x - xOffset - (mouseMoveDist)))
            {
                // if mouse is on left but facing right, switch to face left
                if (isLookingRight)
                {
                    transform.Rotate(0, 180, 0, Space.World); // look into rotate function
                    isLookingRight = false;
                }
                // jumping starts (activate jumping)
                if (mouseSpot.y > (transform.position.y + 3.0f))
                {
                    isJumping = true;
                    isJumpingRight = false;
                    // if the mouse is on the second floor @ x = -9.67, spin jump
                    if (transform.position.y > 3 && transform.position.x < -6.5f)
                    {
                        anim.Play("spinJump");
                        spinJump = true;
                    }
                    else
                        anim.Play("jump");
                }
                // walk
                else if ((transform.position.x - xOffset - mouseSpot.x) < walkDist)
                {
                    // if the character is on the second level, don't let it walk/run past the rail @ x = -13.16
                    nextSpot = new Vector3(transform.position.x + (-1 * walkSpeed), transform.position.y, transform.position.z);
                    if (transform.position.y > 3 && nextSpot.x < -13.16f)
                    {
                        anim.Play("push");
                    }
                    else
                    {
                        transform.Translate(-1 * walkSpeed, 0, 0, Space.World);
                        if (!isCrouching)
                            anim.Play("walk");
                    }
                }
                // run
                else
                {
                    // if the character is on the second level, don't let it walk/run past the rail @ x = -13
                    nextSpot = new Vector3(transform.position.x + (-1 * walkSpeed), transform.position.y, transform.position.z);
                    if (transform.position.y > 3 && nextSpot.x < -13f)
                    {
                        anim.Play("push");
                    }
                    else
                    {
                        transform.Translate(-1 * runSpeed, 0, 0, Space.World);
                        if (!isCrouching)
                            anim.Play("run");
                    }
                }
            }


            // not moving or crouching
            else if (!isCrouching)
            {
                anim.Play("stand");
            }

            // if the player should be crouching but isnt already
            if (mouseSpot.y < transform.position.y - 0.2f && !isCrouching && !isJumping)
            {
                anim.Play("crouch");
                isCrouching = true;
            }

        }
        // mouse not pressed and not jumping
        else if (!isCrouching)
        {
            anim.Play("stand");
        }

        // if the player is crouching and the mouse gets released, stop crouching
        if (Input.GetMouseButtonUp(0) && isCrouching)
        {
            isCrouching = false;
            anim.Play("stand");
        }

        if (isFallingStraight)
        {
            continueFalling();
        }

        // if the character is on the escalator, move it up until it is at the top
        if (isGoingUp)
        {
            // y = 0.8964x - 11.207    from   y = -4.87   to  y = 3.26
            // (7.07, -4.87) and (16.14, 3.26)
            // in vector direction <9.07, 8.13>
            // aka <1, 0.8964>

            if (transform.position.y < 3.26 + 0.7)
            {
                transform.Translate(0.1f, 0.08964f, 0, Space.World);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 3.26f + 0.7f, transform.position.z);
                velocity = 0.8f;
                jumpCount = 0;
                isGoingUp = false;
            }
        }
    }



    // called on the last frame of the crouch animation so the player stays crouched down
    public void stayCrouched()
    {
        anim.Play("crouch one frame");
    }

    public void continueFalling()
    {
        nextSpot = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        if (nextSpot.y < -4.05f)
        {
            transform.position = new Vector3(transform.position.x, -4.05f, transform.position.z);
            anim.Play("stand");
            isFallingStraight = false;
            spinJump = false;
        }
        else 
        {
            transform.Translate(0, -0.3f, 0);
        }
    }


    /* 

      if mouse is clicked or jump is on
          check mouse spot
          if jump right is activated
                move in jump directions
                jumpCount++
                if jump count < jump up frames
                    increase the velocity by tropopican gravitational constant
                else
                    decrease the velocity by tropopican gravitational constant
                    if landed on platform
                        jump deactivated
                        jumpCount = 0
          else if jump left if activated
                move in jump directions
                increase the velocity by tropopican gravitational constant
                jumpCount++
                if jump count < jump up frames
                    increase the velocity by tropopican gravitational constant
                else
                    decrease the velocity by tropopican gravitational constant
                    if landed on platform
                        jump deactivated
                        jumpCount = 0
          else if mouse is on right
                make sure character is facing right
                if mouse is above jump point
                    jumpRight == true
                else! if mouse a bit ahead
                    play walk anim
                    move (walk speed, 0, 0)
                    speed = walk speed
                else a lot in front
                    play run anim
                    move (run speed, 0, 0)
                    speed = run speed
          else mouse is on left
                make sure character is facing left
                if mouse is above jump point
                    jumpLeft == true
                else! if mouse a bit ahead
                    play walk anim
                    move (-walk speed, 0, 0)
                    speed = -walk speed
                else a lot in front
                    play run anim
                    move (-run speed, 0, 0)
                    speed = - run speed

           if mouse is up
                if not already jumping
                    up
                if mouse is clicked, speed = 0 (makes sure that the player only moves forward once per update)
                gravity initialized to 100, init to up
                play jump anim
                if count = 40
                    down
                    gravity = 0.8
                if(up)
                    move(speed, gravity, 0)
                    gravity /= 1.2
                    count ++
                else
                    move(speed, -gravity, 0)
                    gravity *= 1.2
                    if(close platform)
                        land on it in current x position
            if mouse down
                play crouch anim
            check if on platform

    check for platform while jumping
        if the player is within a certain range of a platform that i need to CALCULATE SMT REASONABLE, move to that plateform with kept
        x value and disable jump variable

    check for end of the platform if walking
        if player is at the x of a platform but not the y of the corresponding platform, set it to jump but but the count up so its automatically on fall

    */
}

/*
    moving character with mouse: how I will attempt it'
    
    if(mouse is clicked) move towards the x direction of the mouse
        if(mouse at closer distance) 
            walk + x dir change
        if(mouse at farther distance)
            run + x dir change

    if(character is on the ground and mouse points up)
        if(mouse it a bit up)
            small jump + y dir change
        if( mouse is far up)
            big spin jump + y dir change


    for the inner mall, there are 2 floors and an escalator. The ecsalator has the top and bottom points (7.07, -4.87) and (16.14, 3.26)

    y = ax + b
    -4.87 = 7.07a + b   b = -4.87 - 7.07a
    3.26 = 16.14a + b   b = 3.26 - 16.14a

    -4.87 - 7.07a = 3.26 - 16.14a
    -8.13 = -9.07a
    a = 0.8964
    b = 11.207

    y = 0.8964x - 11.207    from   y = -4.87   to  y = 3.26

    x = (y + 11.207)/0.8964

    *** change 11.207 to 10.5 to prevent feet from stiking out bottom of the escalator

    when the character jumps, if it lands on the escalator, make it rise up until it reaches the top, then it stays on the second level

    

 */