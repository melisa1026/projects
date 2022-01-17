 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls1 : MonoBehaviour
{
    public Vector2 speed = new Vector2(25, 25);                         // speed of whale 
    public Vector2 blockSpot = new Vector2(2.5f, 1);                    // placement of CORRECT block
    public Vector2 blockSize = new Vector2(1.37f, 0.65f);               // half the block size
    public Vector2 badBlock1 = new Vector2(2.5f, 2.9f);                 // the first WRONG block
    public Vector2 badBlock2 = new Vector2(2.5f, -0.85f);               // second
    public Vector2 badBlock3 = new Vector2(2.5f, -2.85f);               // third
    public Animator anim;                                               // place here the animator of the player
    public SpriteRenderer whale;                                        // sprite renderer of whale that can be changed
    public Sprite bad1;                                                 // last frame of 1rst wrong transition anim
    public Sprite bad2;                                                 // last frame of 2nd wrong transition anim
    public Sprite bad3;                                                 // last frame of 3rd wrong transition anim
    public shark shrek;                                                 // shark object


    public Camera MainCamera;
    public float maxY = (float)8;
    public float maxX = (float)16;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        Vector3 curPos = transform.position;

        movement *= Time.deltaTime;

        // only move if player is withing bounds
        if ((curPos.x + movement.x) < (maxX / 2) && (curPos.x + movement.x) > ((maxX / 2)*-1) &&
             (curPos.y + movement.y) < (maxY / 2) - 0.5 && (curPos.y + movement.y) > (maxY / 2)*-1)
       {
            transform.Translate(movement);
       }

        // if spacebar is pressed while on the good block. check that the player's current position is in the right bounds
        if (curPos.x > (blockSpot.x - blockSize.x) && curPos.x < (blockSpot.x + blockSize.x) &&
           curPos.y > (blockSpot.y - blockSize.y) && curPos.y < (blockSpot.y + blockSize.y) &&
           Input.GetKeyDown(KeyCode.Space))
        // switch to the next scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // if spacebar is pressed while on the bad block 1. check that the player's current position is in the right bounds
        if (curPos.x > (badBlock1.x - blockSize.x) && curPos.x < (badBlock1.x + blockSize.x) &&
           curPos.y > (badBlock1.y - blockSize.y) && curPos.y < (badBlock1.y + blockSize.y) &&
           Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("1-glow", -1, 0f);
            whale.sprite = bad1;
        }

        // same but bad block 2
        if (curPos.x > (badBlock2.x - blockSize.x) && curPos.x < (badBlock2.x + blockSize.x) &&
           curPos.y > (badBlock2.y - blockSize.y) && curPos.y < (badBlock2.y + blockSize.y) &&
           Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("1-snout", -1, 0f);
            whale.sprite = bad2;
        }

        // same but bad block 3
        if (curPos.x > (badBlock3.x - blockSize.x) && curPos.x < (badBlock3.x + blockSize.x) &&
           curPos.y > (badBlock3.y - blockSize.y) && curPos.y < (badBlock3.y + blockSize.y) &&
           Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("1-feet", -1, 0f);
            whale.sprite = bad3;
        }
    }

    IEnumerator afterTransition()
    {
        Destroy(anim); // destroy the animator so the sprite is just the set image

        // current position (aka the one they pressed space bar on)
        Vector3 curPos = transform.position;

        // find out the direction the player has to move
        Vector3 toTranslate = new Vector3(((curPos.x + 2.5f)*-1)/50, ((curPos.y)*-1)/50, 0);


        //translate to point (-2.5f, 0, 0)
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(toTranslate);
        }

        shrek.eat();
    }

    public void whaleDisappear()
    {

        whale.enabled = !whale.enabled;
    }
}

/* 

NOTES

after wrong box selected: the animation switches to the treansition and then stays on the image that is the last frame
- when box is clicked, do:   animatior.Play("state", -1, 0f);     // plays transition anim
                             player.sprite = newSprite;           //  switch the sprite to the animation you want it to end on
- at the end of the transition animaton, add an event and attach the Destroy() method to the last frame. In this method, destroy the animator 
  component so that only the sprite shows (which you set to the last frame) code: Destroy(Animator);
- calculate how far the whale must move to get to set spot. divide the x and y values by 50 and (with a coroutine) to create a vector in the same direction but small
  magnitude. With a coroutine, in a for loop that runs 50 times, translate by the direction vector. With each for loop, yield 0.01 seconds!
*/
