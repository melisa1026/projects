using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scarecrowIntro : MonoBehaviour
{
    public Text speech;
    public GameObject clickToContinue, startButton;

    private int count = 1;

    private int matchPoints; // points go up for every matching item between scarecrow and girly

    void Start()
    {
        speech.text = "That pumpkin is so beautiful!! Always gotta appreciate good craftsmanship.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (count == 1)
            {
                speech.text = "Are you ready for the next activity!";
            }
            else if (count == 2)
            {
                speech.text = "I have a wonderful scarecrow outside. We're gonna dress it up to look like me!";
            }
            else
            {
                speech.text = "Now remember what I'm wearing!";
                clickToContinue.SetActive(false);
                startButton.SetActive(true);
            }

            count++;
        }
    }
}
