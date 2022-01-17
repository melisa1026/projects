using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls2 : MonoBehaviour
{
    public Vector2 speed = new Vector2(25, 25);                         // speed of whale 
    public Vector2 blockSpot = new Vector2(2.5f, 1);                    // placement of CORRECT block
    public Vector2 blockSize = new Vector2(1.37f, 0.65f);               // half the block size
    public Vector2 badBlock1 = new Vector2(2.5f, 2.9f);                 // the first WRONG block
    public Vector2 badBlock2 = new Vector2(2.5f, -0.85f);               // second
    public Vector2 badBlock3 = new Vector2(2.5f, -2.85f);               // third
    public Animator anim;                                               // animator or the current whale object
    public SpriteRenderer whale;                                        // the current whale's sprite renderer
    public Sprite bad1;                                                 // last frame of 1rst wrong transition anim
    public Sprite bad2;                                                 // last frame of 2nd wrong transition anim
    public Sprite bad3;                                                 // last frame of 3rd wrong transition anim
    public GameObject tummy;                                            // tummy growl


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
        if ((curPos.x + movement.x) < (maxX / 2) && (curPos.x + movement.x) > ((maxX / 2) * -1) &&
             (curPos.y + movement.y) < (maxY / 2) - 0.5 && (curPos.y + movement.y) > (maxY / 2) * -1)
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
            anim.Play("2-tail", -1, 0f);
            whale.sprite = bad1;
            tummy.SetActive(false);
        }

        // same but bad block 2
        if (curPos.x > (badBlock2.x - blockSize.x) && curPos.x < (badBlock2.x + blockSize.x) &&
           curPos.y > (badBlock2.y - blockSize.y) && curPos.y < (badBlock2.y + blockSize.y) &&
           Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("2-eyes", -1, 0f);
            whale.sprite = bad2;
            tummy.SetActive(false);
        }

        // same but bad block 3
        if (curPos.x > (badBlock3.x - blockSize.x) && curPos.x < (badBlock3.x + blockSize.x) &&
           curPos.y > (badBlock3.y - blockSize.y) && curPos.y < (badBlock3.y + blockSize.y) &&
           Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("2-gills", -1, 0f);
            whale.sprite = bad3;
            tummy.SetActive(false);
        }
    }

    IEnumerator afterTransition()
    {
        // rotate whale 180 degrees, 6 degrees 30 times
        // move up to y = 3

        Destroy(anim); // destroy the animator so the sprite is just the set image

        // current position (aka the one they pressed space bar on)
        Vector3 curPos = transform.position;

        // find out the direction the player has to move
        Vector3 toTranslate = new Vector3(0, ((3 - curPos.y) * -1) / 30, 0);


        //rotate to point 180 degrees
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.015f);
            transform.Rotate(0, 0, 6);
        }

        yield return new WaitForSeconds(0.5f);

        //translate to point up to y = 2.8
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(toTranslate);
        }

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 30; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < 15; j++)
                {
                    yield return new WaitForSeconds(0.01f);
                    transform.Translate(0.1f, 0.01f, 0);
                }
            }

            else 
            {
                for (int j = 0; j < 15; j++)
                {
                    yield return new WaitForSeconds(0.01f);
                    transform.Translate(0.1f, -0.01f, 0);
                }
            }
        }

    }
}
