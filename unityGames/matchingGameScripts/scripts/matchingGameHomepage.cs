using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class matchingGameHomepage : MonoBehaviour
{
    // Stage 1: all players are buttons
    //          one can be pressed
    //          gets marked as player and set to player sprite
    //          player button deactivated
    //          player picture opacity goes down

    // Stage 2: text changed to play AGAINST
    //          one can be pressed
    //          gets marked as opponent sprite
    //          all player buttons deactivated
    //          player picture opacity down
    //          play button becomes visible and activated

    public GameObject mel, sonya, mercedes, pauline, evelyn;
    public Text textbox, playText;
    private string playerName, opponentName;
    public Button playButton;


    public void clickedPlayer(string name)
    {
        // player being chosen
        if (playerName == null)
        {
            if (name == "melisa")
            {
                mel.GetComponent<Renderer>().material.color = Color.green;
                playerName = "melisa";
            }
            else if (name == "sonya")
            {
                sonya.GetComponent<Renderer>().material.color = Color.green;
                playerName = "sonya";
            }
            else if (name == "mercedes")
            {
                mercedes.GetComponent<Renderer>().material.color = Color.green;
                playerName = "mercedes";
            }
            else if (name == "pauline")
            {
                pauline.GetComponent<Renderer>().material.color = Color.green;
                playerName = "pauline";
            }
            else // evelyn
            {
                evelyn.GetComponent<Renderer>().material.color = Color.green;
                playerName = "evelyn";
            }

            switchText();

        }
        // opponent being chosen
        else if (opponentName == null)
        {
            if (name == "melisa" && playerName != "melisa")
            {
                mel.GetComponent<Renderer>().material.color = Color.red;
                opponentName = "melisa";
            }
            else if (name == "sonya" && playerName != "sonya")
            {
                sonya.GetComponent<Renderer>().material.color = Color.red;
                opponentName = "sonya";
            }
            else if (name == "mercedes" && playerName != "mercedes")
            {
                mercedes.GetComponent<Renderer>().material.color = Color.red;
                opponentName = "mercedes";
            }
            else if (name == "pauline" && playerName != "pauline")
            {
                pauline.GetComponent<Renderer>().material.color = Color.red;
                opponentName = "pauline";
            }
            else // evelyn
            {
                if (playerName != "evelyn")
                {
                    evelyn.GetComponent<Renderer>().material.color = Color.red;
                    opponentName = "evelyn";
                }
            }

            textbox.enabled = false;

            playButton.GetComponent<Image>().enabled = true;
            playButton.enabled = true;
            playText.enabled = true;

        }
    }

    public void play()
    {
        globalVariables.player = playerName;
        globalVariables.opponent = opponentName;
    }

    public void switchText()
    {
        textbox.text = "Click who you would like to play against";
    }

    public void nextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
