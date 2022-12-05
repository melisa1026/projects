using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introduction : MonoBehaviour
{
    public Text speech;
    public GameObject nameChooseContainer, talkingContainer;
    public bool nameChosen = false;
    public GameObject clickToContinue, carveButton;

    private int count = 1;

    public void enterName()
    {
        nameChosen = true;
        nameChooseContainer.SetActive(false);
        talkingContainer.SetActive(true);
        speech.text = "Hi! Let me introduce myself. My name is " + characterInfo.witchName + ".";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && nameChosen)
        {
            if(count == 1)
            {
                speech.text = "I like Halloween, Autumn and myself!";
            }
            else if (count == 2)
            {
                speech.text = "I dislike spring, Christmas and haters.";
            }
            else if (count == 3)
            {
                speech.text = "In the future, I aspire to put my amazing talents and smashing looks to use and become an actress.";
            }
            else if (count == 4)
            {
                speech.text = "I'm excited because today I'm going to be doing Autumn activities.";
            }
            else if (count == 5)
            {
                speech.text = "The theme I've chosen is:\nMYSELF!";
            }
            else
            {
                speech.text = "We're gonna start with pumpkin carving! To follow the theme, we're gonna carve my face into the pumpkin:)";
                clickToContinue.SetActive(false);
                carveButton.SetActive(true);
            }

            count++;
        }
    }
}
