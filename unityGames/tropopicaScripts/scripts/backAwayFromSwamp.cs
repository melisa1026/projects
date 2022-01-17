using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backAwayFromSwamp : MonoBehaviour
{
    public Animator anim;
    public talk textSpace;
    public FollowCamera followCamScript;
    public Transform camTrans;

    void Update()
    {
        // if it's in the swamp scene, don't let the player pass x = 1.68
        // go back if the chactaer gets close

        if (transform.position.x > 1.68f && playerControls.controlsActivated)
        {
            playerControls.controlsActivated = false;
            StartCoroutine(moveAway());
        }
    }

    public IEnumerator moveAway()
    {

        transform.position = new Vector3(3.01f, -0.68f, 0.08007813f);
        anim.Play("stand");

        // show the swamp
        followCamScript.activateCameraFollow = false;

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.005f);
            camTrans.Translate(0.16f, 0, 0);
        }

        yield return new WaitForSeconds(1);

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.005f);
            camTrans.Translate(-0.16f, 0, 0);
        }

        followCamScript.activateCameraFollow = true;

        anim.Play("walk");

        // turn t face left
        if (playerControls.isLookingRight)
        {
            transform.Rotate(0, 180, 0, Space.World); // look into rotate function
            playerControls.isLookingRight = false;
        }

        // go to -20
        for (int i = 0; i < 100; i++)
        { 
            transform.Translate(-0.231f, 0, 0, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

        // turn and face right again
        transform.Rotate(0, -180, 0, Space.World);
        playerControls.isLookingRight = true;
        anim.Play("stand");

        yield return new WaitForSeconds(0.2f);

        textSpace.currentSpeech = textSpace.speeches[0];
        textSpace.waitTime = 2;

        textSpace.oneLine();

        yield return new WaitForSeconds(2);

        playerControls.controlsActivated = true;

    }
}
