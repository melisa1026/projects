// problem log
// walk speed isnt right


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerControls : MonoBehaviour
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
    [Range(-2,2)]
    public float mirrorPivotOffset = -1.2f, xOffset, tropocicanGravitationalConstant; 
    public float velocity = 0.3f;

    private Vector3 mirrorToRight = new Vector3(0, -180, 0), mirrorToLeft = new Vector3(0,180,0); // how much to rotate when mirrored
    private Vector3 mouseSpot;
    private bool isJumpingRight = false, isJumping = false, isCrouching = false;
    public static bool isLookingRight = true, isJumpingUp = true;
    private int jumpCount = 0;
    private Vector3 nextSpot;
    private float escalatorLocInThisY;

    public Animator anim;

    public static bool mouseRight;     // global for use in cursor shape too

    public static bool controlsActivated = true; // deactivates controls if other script makes it necessary

    public talk playerSpeechScript;

    // all these are for collecting and using objects
    public GameObject cardToUse, objectOnCard;
    public Text objectName;
    public Camera cam;
    public Vector3 targetPosUseObj;
    public float playerUseObjectTargetX;
    public collectObject collectObjectScript;


    private void Start()
    {
        // make sure the character enters from the right side/door
        transform.position = staticVariables.enterLocation;
        if (staticVariables.comeInRight)
        {
            isLookingRight = true;
        }
        else 
        {
            transform.Rotate(0, 180, 0, Space.World);
            isLookingRight = false;
        }

        // if a character chooses to use an object that it doesn't need
        if (SceneManager.GetActiveScene().name != staticVariables.useObjectSceneName)
        {
            if (staticVariables.pressedUseUselessObj)
            {
                playerSpeechScript.oneLine();
                staticVariables.pressedUseUselessObj = false;
            }
        }
        else if(staticVariables.pressedUseUselessObj)// in pop fashion scene
        {
            StartCoroutine(useItem());
        }
    }

    private void Update()
    {
        if (controlsActivated)
        {
            // check the posiiton of the mouse
            mouseSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);



            // if mouse button is down
            if (Input.GetMouseButton(0) || isJumping)
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
                            transform.Translate(-1 * walkSpeed, velocity, 0, Space.World);
                    }
                    // is falling downwards
                    else
                    {

                        if (isJumpingRight)
                            transform.Translate(walkSpeed, -1 * velocity, 0, Space.World);
                        else
                            transform.Translate(-1 * walkSpeed, -1 * velocity, 0, Space.World);
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
                    else
                    {
                        isJumping = false;
                        isJumpingUp = true;
                        jumpCount = 0;
                        anim.Play("stand");
                    }
                }
                // if the mouse is on the right + a bit
                else if (mouseSpot.x > (transform.position.x - xOffset + mouseMoveDist))
                {
                    // if mouse clicked right but facing left, switch to face right
                    if (!isLookingRight)
                    {
                        transform.Rotate(0, -180, 0, Space.World);
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
                        anim.Play("jump");
                    }
                    // walk
                    else if ((transform.position.x - xOffset - mouseSpot.x) < walkDist)
                    {
                        transform.Translate(-1 * walkSpeed, 0, 0, Space.World);
                        if (!isCrouching)
                            anim.Play("walk");
                    }
                    // run
                    else
                    {
                        transform.Translate(-1 * runSpeed, 0, 0, Space.World);
                        if (!isCrouching)
                            anim.Play("run");
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
        }

    }

    // called on the last frame of the crouch animation so the player stays crouched down
    public void stayCrouched()
    {
        anim.Play("crouch one frame");
    }

    public IEnumerator useItem()
    {
        controlsActivated = false;

        // move character to desired position
        Vector3 charDistPerFrame = new Vector3((playerUseObjectTargetX - transform.position.x) / 50, 0, 0);

        anim.Play("walk");

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(charDistPerFrame, Space.World);
        }

        anim.Play("stand");

        yield return new WaitForSeconds(0.1f);
        float camHalfHeight = cam.orthographicSize;
        float camHalfWidth = camHalfHeight * cam.aspect;

        Transform trans = cardToUse.GetComponent<Transform>();
        Transform camTrans = cam.GetComponent<Transform>();

        SpriteRenderer cardRend = cardToUse.GetComponent<SpriteRenderer>();
        SpriteRenderer objRend = objectOnCard.GetComponent<SpriteRenderer>();

        // make the card visible
        cardRend.enabled = true;
        objRend.enabled = true;
        objectName.enabled = true;

        // set initial position and scale to basically 0 scale on top of bag
        trans.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        trans.position = new Vector3((camHalfWidth - 1), (camHalfHeight - 1), 0); // set the object to be at the bag

        // the target position is in the middle of the screen: (camTrans.position.x, camTrans.position.y, trans.position.z);

        // check how far to move per frame to end up at the middle big
        Vector3 distPerFrame = new Vector3((camTrans.position.x - trans.position.x) / 30, (camTrans.position.y - trans.position.y) / 30, 0);

        // upsize and move card over 30 frames
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            trans.Translate(distPerFrame);
            trans.localScale = new Vector3(trans.localScale.x + 0.4f, trans.localScale.y + 0.4f, trans.localScale.z);
        }

        // pause while card is big
        yield return new WaitForSeconds(1);

        // now I want the card to go where it's being used
        // the new target position is in the public variable "targetPosUseObj"

        // find the distance per frame
        distPerFrame = new Vector3((targetPosUseObj.x - trans.position.x)/30, (targetPosUseObj.y - trans.position.y) / 30, 0);

        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            trans.Translate(distPerFrame);
            trans.localScale = new Vector3(trans.localScale.x - 0.4f, trans.localScale.y - 0.4f, trans.localScale.z);
        }

        if (SceneManager.GetActiveScene().name == "PopFashion")
        {
            staticVariables.coins = false;

            // now collect the tshirt
        }

        yield return new WaitForSeconds(0.5f);

        collectObjectScript.collect();
        staticVariables.shirtNet = true;

        // remove the object from the scene
        cardToUse.SetActive(false);
        staticVariables.pressedUseUselessObj = false;
        controlsActivated = true;
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



    

 */