using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class falling : MonoBehaviour
{
    // public vars
    public float boxBound1 = 4.53f;
    public float boxBound2 = 6.89f;
    public float bad1Bound1 = -6.53f;
    public float bad1Bound2 = -4.21f;
    public float bad2Bound1 = -2.78f;
    public float bad2Bound2 = -0.27f;
    public float bad3Bound1 = 0.99f;
    public float bad3Bound2 = 3.31f;
    public Vector2 speed = new Vector2(25, 25);                       // speed of whale 
    public float maxX = 8f;
    public float minX = 8f;
    public Animator anim;
    public SpriteRenderer whale;
    public string badBlockStr1 = "4-hands";
    public string badBlockstr2 = "4growFeetLev4";
    public string badBlockStr3 = "4-mouth";
    public GameObject cloud1, cloud2, cloud3, ground;


    private void Update()
    {


        float inputX = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(speed.x * inputX, 0, 0);
        Vector3 curPos = transform.position;

        movement *= Time.deltaTime;

        // only move if player is withing bounds
        if (((curPos.x + movement.x) < (maxX)) && (curPos.x + movement.x) > ((minX) * -1))
        {

            transform.Translate(movement);
        }

        if (curPos.x > boxBound1 && curPos.x < boxBound2 && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (curPos.x > bad1Bound1 && curPos.x < bad1Bound2 && Input.GetKeyDown(KeyCode.Space))
        {
            enabled = false;
            anim.enabled = true;
            anim.Play(badBlockStr1, -1, 0f);
        }

        if (curPos.x > bad2Bound1 && curPos.x < bad2Bound2 && Input.GetKeyDown(KeyCode.Space))
        {
            enabled = false;
            anim.enabled = true;
            anim.Play(badBlockstr2, -1, 0f);
        }

        if (curPos.x > bad3Bound1 && curPos.x < bad3Bound2 && Input.GetKeyDown(KeyCode.Space))
        {
            enabled = false;
            anim.enabled = true;
            anim.Play(badBlockStr3, -1, 0f);
        }
    }

    public void destroyAnim(Sprite badBlock)
    {
        whale.sprite = badBlock;
        Destroy(anim);
    }

    public IEnumerator smashGround()
    {
        Destroy(cloud1);
        Destroy(cloud2);
        Destroy(cloud3);

        Vector3 translateAmount = new Vector3(0, -0.0412f, 0), smallerFall = new Vector3(0, -0.07f, 0), scaleAmount = new Vector3(0, 0.01088f, 0),
            groundUp = new Vector3(0, 0.0412f, 0);
 
        // move to ground
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Translate(translateAmount);
            ground.transform.Translate(groundUp);
        }

        // squish and absorb
        for (int i = 0; i < 25; i++)
        {
            yield return new WaitForSeconds(0.0001f);
            transform.localScale -= scaleAmount;
            transform.Translate(smallerFall);
        }
    }

    public IEnumerator smashTree()
    {
        // character smash into tree (x = 3.7) and then fall

        // calculate amount it needs to move in the x direction
        float xPos = transform.position.x;
        float amountToMove = (3.7f - xPos);

        // i will move within 50 movements, so divde the amount to move in 60
        float amountToMovePerLoop = amountToMove / 60;

        // i want the character to also pulse up and down like it's flying, so every 10, it will switch directions (up/down)
        Vector3 upDir = new Vector3(amountToMovePerLoop, 0.005f, 0);
        Vector3 downDir = new Vector3(amountToMovePerLoop, -0.005f, 0);

        yield return new WaitForSeconds(0.5f);

        // do a nested loop, inner loop switches up/down and full loop moves forward
        for (int i = 0; i < 12; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < 5; j++)
                {
                    transform.Translate(upDir);
                    yield return new WaitForSeconds(0.005f);
                }
            }

            else
            {
                for (int k = 0; k < 5; k++)
                {
                    transform.Translate(downDir);
                    yield return new WaitForSeconds(0.005f);
                }
            }
        }

        // has to fall 6 units
        Vector3 fallAmountPerLoop = new Vector3(0, -0.2f, 0);
        Vector3 rotateAmountPerLoop = new Vector3(0, 0, 0.25f);

        // fall to ground
        for (int i = 0; i < 100; i++)
        {
            transform.Translate(fallAmountPerLoop);
            transform.Rotate(rotateAmountPerLoop);
            yield return new WaitForSeconds(0.005f);
        }
    }


}