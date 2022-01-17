using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class custom : MonoBehaviour
{
    public Button[] textButts;

    public Button[] hairButts;

    public Button[] skinButts;

    public Button[] outfitButts;

    public Button backButton;

    public Text backButtonText;

    public Sprite[] lightSkin, mediumSkin, darkSkin;

    public Texture2D defaultCursor;

    // the sprites on the actual characters
    public SpriteRenderer outfit;
    public SpriteRenderer hair;
    public SpriteRenderer[] skin; // order: head, torso, right arm, left arm, right leg, left leg

    public GameObject outfitObj, hairObj;

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);

        if(staticVariables.hairSprite != null)
            setHair(staticVariables.hairSprite);

        if(staticVariables.skinColour != null)
            setSkin(staticVariables.skinColour);

        if(staticVariables.outfitSprite != null)
        setOutfit(staticVariables.outfitSprite);

        if (staticVariables.hairPosX != 0)
            translatePosX(staticVariables.hairPosX);
        if (staticVariables.hairPosY != 0)
            translatePosY(staticVariables.hairPosY);
        if (staticVariables.fitPosX != 0)
            setFitPosX(staticVariables.fitPosX);
        if (staticVariables.fitPosY != 0)
            setFitPosY(staticVariables.fitPosY);
        if (staticVariables.hairScale != 0)
            scaleHair(staticVariables.hairScale);
    }


    public void setHair(Sprite hairy) 
    {
        hair.sprite = hairy;

        staticVariables.hairSprite = hairy;
    }

    // pass in an array of the corresponding coloured body parts 
    public void setSkin(string colour)
    {
        Sprite[] bodyParts;

        if (colour == "light")
            bodyParts = lightSkin;
        else if (colour == "medium")
            bodyParts = mediumSkin;
        else
            bodyParts = darkSkin;

        staticVariables.skinColour = colour;

        skin[0].sprite = bodyParts[0];
        skin[1].sprite = bodyParts[1];
        skin[2].sprite = bodyParts[2];
        skin[3].sprite = bodyParts[3];
        skin[4].sprite = bodyParts[4];
        skin[5].sprite = bodyParts[5];

        staticVariables.skinSprites = bodyParts;
    }

    public void setOutfit(Sprite fit)
    {
        outfit.sprite = fit;

        staticVariables.outfitSprite = fit;
    }

    public void disableTextButtons()
    { 
        for (int i = 0; i < textButts.Length; i++)
        {
            textButts[i].enabled = false;
            textButts[i].GetComponent<Transform>().GetChild(0).GetComponent<Text>().enabled = false;
        }
    }

    public void openHairs()
    {
        disableTextButtons();
        enableBackButton();

        for (int i = 0; i < hairButts.Length; i++)
        {
            hairButts[i].enabled = true;
            hairButts[i].GetComponent<Image>().enabled = true;
        }
    }

    public void openSkins()
    {
        disableTextButtons();
        enableBackButton();

        for (int i = 0; i < skinButts.Length; i++)
        {
            skinButts[i].enabled = true;
            skinButts[i].GetComponent<Image>().enabled = true;
        }
    }

    public void openOutfits()
    {
        disableTextButtons();
        enableBackButton();

        for (int i = 0; i < outfitButts.Length; i++)
        {
            outfitButts[i].enabled = true;
            outfitButts[i].GetComponent<Image>().enabled = true;
        }
    }

    public void translatePosX(float posX)
    {
        Vector3 newPos = new Vector3(posX, hairObj.GetComponent<Transform>().localPosition.y, hairObj.GetComponent<Transform>().localPosition.z);
        hairObj.GetComponent<Transform>().localPosition = newPos;

        staticVariables.hairPosX = posX;
    }

    public void translatePosY(float posY)
    {
        Vector3 newPos = new Vector3(hairObj.GetComponent<Transform>().localPosition.x, posY, hairObj.GetComponent<Transform>().localPosition.z);
        hairObj.GetComponent<Transform>().localPosition = newPos;

        staticVariables.hairPosY = posY;
    }

    public void scaleHair(float scaleFact)
    {
        Vector3 newScale = new Vector3(scaleFact, scaleFact, scaleFact);
        hairObj.GetComponent<Transform>().localScale = newScale;

        staticVariables.hairScale = scaleFact;
    }

    public void setFitPosX(float posX)
    {
        Vector3 newPos = new Vector3(posX, outfitObj.GetComponent<Transform>().localPosition.y, outfitObj.GetComponent<Transform>().localPosition.z);
        outfitObj.GetComponent<Transform>().localPosition = newPos;

        staticVariables.fitPosX = posX;
    }

    public void setFitPosY(float posY)
    {
        Vector3 newPos = new Vector3(outfitObj.GetComponent<Transform>().localPosition.x, posY, outfitObj.GetComponent<Transform>().localPosition.z);
        outfitObj.GetComponent<Transform>().localPosition = newPos;

        staticVariables.fitPosY = posY;
    }

    public void enableBackButton()
    {
        backButton.enabled = true;
        backButtonText.enabled = true;
    }

    public void disableBackButton()
    {
        backButton.enabled = false;
        backButtonText.enabled = false;
    }
    
    public void backButtonPress()
    {
        disableBackButton();

        // put back the texts
        for (int i = 0; i < textButts.Length; i++)
        {
            textButts[i].enabled = true;
            textButts[i].GetComponent<Transform>().GetChild(0).GetComponent<Text>().enabled = true;
        }

        // remove the hair buttons
        for (int i = 0; i < hairButts.Length; i++)
        {
            hairButts[i].enabled = false;
            hairButts[i].GetComponent<Image>().enabled = false;
        }

        // remove skin buttons
        for (int i = 0; i < skinButts.Length; i++)
        {
            skinButts[i].enabled = false;
            skinButts[i].GetComponent<Image>().enabled = false;
        }

        // remove outfit buttons
        for (int i = 0; i < outfitButts.Length; i++)
        {
            outfitButts[i].enabled = false;
            outfitButts[i].GetComponent<Image>().enabled = false;
        }
    }

}