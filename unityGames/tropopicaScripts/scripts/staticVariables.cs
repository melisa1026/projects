using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class staticVariables : MonoBehaviour
{
    public static Vector3 enterLocation;
    public static bool comeInRight;

    public SpriteRenderer outfit;
    public SpriteRenderer hair;
    public SpriteRenderer[] skin; // order: head, torso, right arm, left arm, right leg, left leg

    public static Sprite outfitSprite = null;
    public static Sprite hairSprite = null;
    public static Sprite[] skinSprites = null; // order: head, torso, right arm, left arm, right leg, left leg
    public static string skinColour = null;

    public static float hairScale, hairPosX, hairPosY;
    public static float fitPosX, fitPosY;

    public static bool pressedUseUselessObj = false; // when true, character says "I don't need to use this now and stops using it"

    public static string runningScene = "InnerMall";

    // make a boolean to indicate each item's collected status
    public static bool newspaper = false, coins = false, shirtNet = false, catchNet = false, stick = false, fabrics = false,
                    coralSnake = false, purpleSnake = false, blackTellowSnake = false, mouse = false, waterPump = false;

    // marks the activation of buttons
    public static bool vendingButtonActive = true, newsButton = true, materialButtons = true;

    public static string useObjectSceneName; // when use is pressed on an object, the scene it's used in gets put here

    public static bool hasReadNewspaper = false, hasSpokenToRFC = false;

    public static bool hasFadedIn = false; // when going to talk to jimmy, I'm gonna do a fade fade out. This is necessary for the scene change

    public Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (enterLocation.y == 0)
        {
            enterLocation = new Vector3(-5.74f, -4.05f, 0.08007813f);
            comeInRight = false;
        }

        if (SceneManager.GetActiveScene().name != "characterCustom" && SceneManager.GetActiveScene().name != "Backpack")
        {
            runningScene = SceneManager.GetActiveScene().name;
        }

        setFit();
        setSkin();
        setHair();

        // check if it's time to tell Jimmy about the plan!
        // fade out of current scene
        if(SceneManager.GetActiveScene().name != "Backpack" && blackScreen != null)
            StartCoroutine(checkIfFadeOut());
    }

    public void setEnterLocationX(float enterLocX)
    { 
        enterLocation.x = enterLocX;
    }

    public void setEnterLocationY(float enterLocY)
    {
        enterLocation.y = enterLocY;
    }

    public void setComeInRight(bool inRight)
    {
        comeInRight = inRight;
    }

    public void setHair()
    {
        if (hairSprite != null)
        {
            hair.sprite = hairSprite;

            Vector3 newPos = new Vector3(hairPosX, hairPosY, hair.GetComponent<Transform>().localPosition.z);
            hair.GetComponent<Transform>().localPosition = newPos;

            Vector3 newScale = new Vector3(hairScale, hairScale, hairScale);
            hair.GetComponent<Transform>().localScale = newScale;
        }
    }

    public void setSkin()
    {
        if (skinSprites != null)
        {
            skin[0].sprite = skinSprites[0];
            skin[1].sprite = skinSprites[1];
            skin[2].sprite = skinSprites[2];
            skin[3].sprite = skinSprites[3];
            skin[4].sprite = skinSprites[4];
            skin[5].sprite = skinSprites[5];
        }
    }

    public void setFit()
    {
        if (outfitSprite != null)
        {
            outfit.sprite = outfitSprite;

            Vector3 newPos = new Vector3(fitPosX, fitPosY, outfit.GetComponent<Transform>().localPosition.z);
            outfit.GetComponent<Transform>().localPosition = newPos;
        }
    }

    public void setUseObjectSceneName(string sceneName)
    {
        useObjectSceneName = sceneName;
    }

    public void setPressedUselessObjectTrue()
    {
        pressedUseUselessObj = true;
    }

    public void goToRunningScene()
    {
        SceneManager.LoadScene(runningScene);
    }

    public void setHasReadNewspaperTrue()
    {
        hasReadNewspaper = true;
    }

    public IEnumerator checkIfFadeOut()
    {
        yield return new WaitForSeconds(0);

        
        if (hasReadNewspaper && hasSpokenToRFC && !hasFadedIn)
        {
            blackScreen.enabled = true;
            Animator anim = blackScreen.GetComponent<Animator>();
            anim.enabled = true;
            anim.Play("blackin");
            hasFadedIn = true;
            enterLocation = new Vector3(-5.74f, -4.05f, 0.08007813f);
        }
        else if (hasReadNewspaper && hasSpokenToRFC)
        {
            Animator anim = blackScreen.GetComponent<Animator>();
            anim.Play("blackout");
            anim.enabled = true;
            blackScreen.enabled = true;

            hasReadNewspaper = false;
            hasSpokenToRFC = false;
        }
    }

    public void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void turnOffBlackout()
    {
        blackScreen.enabled = false;
    }
}
