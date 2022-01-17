using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class littleWalkWhale : MonoBehaviour
{

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

        if (inputX == 0)
        {
            anim.enabled = false;
        }

        else
        {
            anim.enabled = true;
        }

        if(curPos.x > boxBound1 && curPos.x < boxBound2 && Input.GetKeyDown(KeyCode.Space))
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

}