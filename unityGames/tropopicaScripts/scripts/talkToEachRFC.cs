using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkToEachRFC : MonoBehaviour
{
    public GameObject[] textboxes;  // 0: Hissy Slania
                                    // 1: Boa Gardner
                                    // 2: Py Thondurla
                                    // 3: Nicole Cobratio
                                    // 4: Anna Conda
                                    // 5: player
    public Text[] texts;

    public string[] speeches = { "WE'RE VISITING THIS TOWN TO SEE THIS FAMOUS BIRD ATTRACTION.",
                                 "DID YOU KNOW THAT BIRDS ARE REPTILES?",
                                 "WE ARE SO FASCINATED BY THE TOWN'S SNAKE SPECIES DIVERSITY!",
                                 "THE ONLY THING THE REPTILE FANATIC GROUP LIKES MORE THAN REPTILES IS FASHION!",
                                 "THERE IS NOTHING TO DO IN THIS TOWN! WE'RE HERE ALL WEEK AND THE ONLY THING TO DO IS BIRDWATCH!",
                                 "PETROPICA IS PLANNING A COOL REPTILE EVENT TOMORROW, YOU GUYS CAN ALL COME!"};

    public GameObject[] characters;

    private int j; // current character number from above list

    private int count = 0; // increase the count and recall the talkSequence coroutine every character encounter

    private GameObject tempCharacter = null;

    private int waitTime;

    public void talkSequence()
    {
        staticVariables.hasSpokenToRFC = true;

        // player goes to face Py and speaks to him
        // player goes to face Boa and speaks to him
        // player goes to face Nicole and speaks to him
        // player goes to face Anna and speaks to him
        // player goes to face Hissy and speaks to him
        // so same thing 5 times w/ different characters and lines

        // each time, check if the character is on the right or left of the screen to determine what side of them the player should be on
        // turn off the walkingCharacters script on the player to make sure they don't walk away while talking

        playerControls.controlsActivated = false;
        
        // check which character is being talked to next
        switch(count)
        {

            case 0:
                {
                    j = 2;
                    waitTime = 3;
                    break;
                }
            case 1:
                {
                    j = 1;
                    waitTime = 3;
                    break;
                }
            case 2:
                {
                    j = 3;
                    waitTime = 3;
                    break;
                }
            case 3:
                {
                    j = 4;
                    waitTime = 5;
                    break;
                }
            default:
                {
                    j = 0;
                    waitTime = 6;
                    break;
                }
        }

        tempCharacter = characters[j];

        // if the character is on the right of the scene
        if (tempCharacter.GetComponent<Transform>().position.x > 0)
        {
            // make them face left (if not already)
            if (tempCharacter.GetComponent<walkingCharacters>().isLookingRight)
            {
                tempCharacter.GetComponent<Transform>().Rotate(0, 180, 0, Space.World);
                tempCharacter.GetComponent<walkingCharacters>().isLookingRight = false;
            }


            // deactivate the walking script temporarily
            tempCharacter.GetComponent<Animator>().Play("stand");
            tempCharacter.GetComponent<walkingCharacters>().enabled = false;

            // move the player to the talking character
            Vector3 speakerPos = tempCharacter.GetComponent<Transform>().position;
            StartCoroutine(moveToSpeaker(false, speakerPos));
        }
        else // character is on the left
        {
            // make them face right (if not already)
            if (!tempCharacter.GetComponent<walkingCharacters>().isLookingRight)
            {
                tempCharacter.GetComponent<Transform>().Rotate(0, -180, 0, Space.World);
                tempCharacter.GetComponent<walkingCharacters>().isLookingRight = true;
            }

            // deactivate the walking script temporarily
            tempCharacter.GetComponent<Animator>().Play("stand");
            tempCharacter.GetComponent<walkingCharacters>().enabled = false;

            // move the player to the talking character
            Vector3 speakerPos = tempCharacter.GetComponent<Transform>().position;
            StartCoroutine(moveToSpeaker(true, speakerPos));
        }

    }

    public IEnumerator oneLine()
    {
        yield return new WaitForSeconds(0);


        bool textFlipped = false; 

        // if the speaker is facing left, flip the text (when speaker is on the right of the screen)
        if (tempCharacter.GetComponent<Transform>().position.x > 0)
        {
            textFlipped = true;
            texts[j].GetComponent<Transform>().Rotate(0, 180, 0, Space.World);
        }

        // enable the textbox and text
        textboxes[j].GetComponent<SpriteRenderer>().enabled = true;
        texts[j].text = speeches[count];
        texts[j].enabled = true;
        
        yield return new WaitForSeconds(waitTime);

        if (textFlipped)
        {
            textFlipped = false;
            texts[j].GetComponent<Transform>().Rotate(0, -180, 0, Space.World);
        }

        // enable the textbox and text
        textboxes[j].GetComponent<SpriteRenderer>().enabled = false;
        texts[j].enabled = false;
        
        tempCharacter.GetComponent<walkingCharacters>().enabled = true;

        // now move on to the next character
        count++;
        if (count < 5)
            talkSequence();
        // after all the characters talk, it is now the player's turn
        else if (count == 5)
        {
            StartCoroutine(playerLine());
        }

    }

    public IEnumerator playerLine()
    { 
        bool textFlipped = false;

        // if the speaker is facing left, flip the text (when hissy slania is on the left side)
        if (characters[0].GetComponent<Transform>().position.x < 0)
        {
            textFlipped = true;
            texts[5].GetComponent<Transform>().Rotate(0, 180, 0, Space.World);
        }
        texts[5].text = speeches[5];
        texts[5].enabled = true;
        textboxes[5].GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(5);

        texts[5].enabled = false;
        textboxes[5].GetComponent<SpriteRenderer>().enabled = false;

        if (textFlipped)
        {
            textFlipped = false;
            texts[5].GetComponent<Transform>().Rotate(0, -180, 0, Space.World);
        }

        // now reset everything

        // player controls activated
        playerControls.controlsActivated = true;

        // reset count so the player can talk to everyone again
        count = 0;

        // reactivate the button to talk to everyone
    }

    public IEnumerator moveToSpeaker(bool goOnRight, Vector3 speakerPos)
    {
        // player walks to the speaker @ x = 5 away (from right or left)
        // player turns to face character
        // player now stands

        // switch the character animation to walking
        characters[5].GetComponent<Animator>().Play("walk");


        float targetPosX;
        if (goOnRight)
            targetPosX = speakerPos.x + 2;
        else
            targetPosX = speakerPos.x - 2;

        // face the walking direction
        // face right if the target position is > current position and not already facing right
        if (targetPosX > characters[5].GetComponent<Transform>().position.x && !playerControls.isLookingRight)
        {
            characters[5].GetComponent<Transform>().Rotate(0, -180, 0, Space.World);
            playerControls.isLookingRight = true;
        }
        // of the targer position < current position and not already looking left
        else if (targetPosX < characters[5].GetComponent<Transform>().position.x && playerControls.isLookingRight)
        {
            characters[5].GetComponent<Transform>().Rotate(0, 180, 0, Space.World);
            playerControls.isLookingRight = false;
        }

        // distance per frame: target position - current position - 50
        float distPerFrame = (targetPosX - characters[5].GetComponent<Transform>().position.x)/50;

        for (int i = 0; i < 50; i++)
        {
            characters[5].GetComponent<Transform>().Translate(distPerFrame, 0, 0, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

        characters[5].GetComponent<Animator>().Play("stand");

        // turn and face the speaker if necessary
        // if the character went to the right and it facing right, turn left
        if (playerControls.isLookingRight && goOnRight)
        {
            characters[5].GetComponent<Transform>().Rotate(0, -180, 0, Space.World);
            playerControls.isLookingRight = false;
        }
        // if player is on the left and looking left, turn right
        else if (!playerControls.isLookingRight && !goOnRight)
        {
            characters[5].GetComponent<Transform>().Rotate(0, 180, 0, Space.World);
            playerControls.isLookingRight = true;
        }

        // next the character talks one line
        StartCoroutine(oneLine());
    }
                                    
}


// !!!!!!!!!!!!! keep in mind that the distance from the left and right are not the same


// need to reactivate after whole thing
// reactivate the character walking script
//tempCharacter.GetComponent<walkingCharacters>().enabled = true;