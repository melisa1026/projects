using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
    public string[] speeches;
    public string normalAnimState; // state before and after talking
    public GameObject textbox;
    public GameObject character, player;
    public Text textSpace;
    private bool textFlipped = false;

    public string currentSpeech;
    public int waitTime;

    private void Start()
    {
        currentSpeech = speeches[0];
        waitTime = 6;
    }

    public void setCurrentSpeech(int cur)
    {
        currentSpeech = speeches[cur];
    }

    public void setWaitTime(int time)
    {
        waitTime = time;
    }

    public void oneLine()
    {
        StartCoroutine(oneLineIEnum());
    }

    public IEnumerator oneLineIEnum()
    {
        yield return new WaitForSeconds(0);
        SpriteRenderer textboxRen = textbox.GetComponent<SpriteRenderer>();
        textSpace.text = currentSpeech;
        textboxRen.enabled = true;
        textSpace.enabled = true;

        
        // if the player is facing left, flip the text
        if (!playerControls.isLookingRight && character == player)
        {
            textFlipped = true;
            transform.Rotate(0, 180, 0, Space.World);
        }

        yield return new WaitForSeconds(waitTime);

        textboxRen.enabled = false;
        textSpace.enabled = false;

        if (textFlipped) 
        {
            textFlipped = false;
            transform.Rotate(0, -180, 0, Space.World);
        }
        
    }
}
