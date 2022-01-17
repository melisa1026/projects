
/*
 * This page should open with a parameter-given sentence, depending on the lost level, and save the level/scene number
 * It has a try again button that changes to the scene lost on
 * it has a restart game button that returns to the home page
 * 
 * when level is lost, function must save scene number and send level loss text, then change scenes
 * 
 * possible problem: will everything reset when i go back to the scene? or will it be as I left it?
 * 
 * for some reason i can't have a string param from animation even so instead ill put all the strings here and
 * choose one depending on which level is lost
 * 
 * 
 * !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 * What to do next:
 * I put the animationEndAndNextStart on the yellow flash. Make the next animation the whale glow in the dark eye transition. Make this on
 * ipad, it hasnt been done yet. Then transition straight into outro page:)
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class losingPage : MonoBehaviour
{
    static int lostSceneNum;               // the scene number of the level lost
    public Text textbox;            // box that text goes in
    static string text;             // text string that will go in the box
    const int losingPageNum = 21;   // number of the YOU LOSE page
    public float waitTime;          // time to wait before switching to lose scene

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == losingPageNum)
        { 
            textbox.text = text;
        }
    }
    // function callled to set the page up and open it
    public IEnumerator setPage(int lostSceneNumber)
    {
        yield return new WaitForSeconds(waitTime);

        lostSceneNum = lostSceneNumber;
        text = getString(lostSceneNum);

        SceneManager.LoadScene("LosingScene");
    }

    // funtion called try level again
    public void tryAgain()
    {
        SceneManager.LoadScene(lostSceneNum);
    }

    // function that goes back to home page 
    public void goToHomePage()
    {
        SceneManager.LoadScene("Homepage");
    }

    // choose string
    string getString(int lostSceneNum)
    {

        switch(lostSceneNum)
        { 
            case 0:
                return "Your whale was eaten by a shark.";
            case 2:
                return "Your whale starved.";
            case 4:
                return "Your whale was washed up and got stuck.";
            case 6:
                return "Your whale's spout kept squirting water in its eyes\nand it couldn't see.";
            case 8:
                return "Your whale got pathetically stuck behind a little log.";
            case 10:
                return "Your whale's body has a really awkward weight\ndistribution and can't balance well.";
            case 12:
                return "Your whale starved.";
            case 14:
                return "Your whale's head overheated.";
            case 16:
                return "Your whale fell off a cliff and smashed the ground\nfrom deadly heights.";
            case 18:
                return "Your whale slammed into a tree and fell from the sky\nbecause it cannot navigate in the dark.";
            default:
                return "I forgot to write one if the levels";

        }
    }

}
