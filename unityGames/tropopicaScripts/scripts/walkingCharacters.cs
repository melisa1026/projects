using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class walkingCharacters : MonoBehaviour
{
    public float startLoc; // start x location
    public bool isGoingRight;
    public Animator anim;
    [Range(0.01f, 0.1f)]
    public float speed;
    public bool isLookingRight;
    private bool isPacingForest = false; // makes sure the forest walk is not called multiple times
    public int aNum; // the random number that will make the character stand

    private Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startLoc, transform.position.y, transform.position.z);
        // all characters start facing the right
        isLookingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(paceForest());
    }

    public IEnumerator paceForest()
    {
        if (!isPacingForest)
        {
            isPacingForest = true;

            // stand for a bit when random number 1 is chosen
            if (random.Next(200) == aNum)
            {
                anim.Play("stand");
                yield return new WaitForSeconds(random.Next(20));
            }
            else
            {
                anim.Play("walk");
                // go right untl reaching x = 20, then left until reaching x = -20
                if (isGoingRight)
                {

                    if (!isLookingRight)
                    {
                        transform.Rotate(0, -180, 0, Space.World);
                        isLookingRight = true;
                    }

                    yield return new WaitForSeconds(0.01f);
                    transform.Translate(speed, 0, 0, Space.World);

                    if (transform.position.x > 18)
                        isGoingRight = false;
                }
                else // going left
                {
                    if (isLookingRight)
                    {
                        transform.Rotate(0, 180, 0, Space.World); // look into rotate function
                        isLookingRight = false;
                    }

                    yield return new WaitForSeconds(0.01f);
                    transform.Translate(-1 * speed, 0, 0, Space.World);

                    if (transform.position.x < -18)
                        isGoingRight = true;
                }
            }

            isPacingForest = false;
        }
    }
}
