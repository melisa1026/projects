using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterCustom : MonoBehaviour
{

    public GameObject eyes, nose, mouth, skin, hair, top, bottom, hat; // character parts
    public GameObject categoryContainer, eyesContainer, noseContainer, mouthContainer, skinContainer, hairContainer, hairColourContainer,
        topContainer, bottomContainer, hatContainer; // the empty game objects that contain the option menus for each customizable part
    public GameObject backButton;

    // public Color red = new Color(0, 0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        characterInfo.skinColour = new Color(200/255f, 178/255f, 108/255f, 1);
        characterInfo.hairColour = new Color(84/255f, 48/255f, 22/255f, 1);
    }

    public void changeEyes(Sprite newEyes)
    {
        eyes.GetComponent<SpriteRenderer>().sprite = newEyes;
        characterInfo.eyes = newEyes;
    }

    public void changeNose(Sprite newNose)
    {
        nose.GetComponent<SpriteRenderer>().sprite = newNose;
        characterInfo.nose = newNose;
    }

    public void changeMouth(Sprite newMouth)
    {
        mouth.GetComponent<SpriteRenderer>().sprite = newMouth;
        characterInfo.mouth = newMouth;
    }

    public void changeHair(Sprite newHair)
    {
        hair.GetComponent<SpriteRenderer>().sprite = newHair;
        characterInfo.hair = newHair;
    }

    public void changeTop(Sprite newTop)
    {
        top.GetComponent<SpriteRenderer>().sprite = newTop;
        characterInfo.top = newTop;
    }

    public void changeBottom(Sprite newBottom)
    {
        bottom.GetComponent<SpriteRenderer>().sprite = newBottom;
        characterInfo.bottom = newBottom;
    }

    public void changeHat(Sprite newHat)
    {
        hat.GetComponent<SpriteRenderer>().sprite = newHat;
        characterInfo.hat = newHat;
    }

    public void changerHairColour(string newColour)
    {
        if(newColour == "red")
            hair.GetComponent<SpriteRenderer>().color = new Color(190 / 255f, 89 / 255f, 58 / 255f, 1);
        else if (newColour == "orange")
            hair.GetComponent<SpriteRenderer>().color = new Color(238 / 255f, 161 / 255f, 75 / 255f, 1);
        else if (newColour == "yellow")
            hair.GetComponent<SpriteRenderer>().color = new Color(250 / 255f, 220 / 255f, 112 / 255f, 1);
        else if (newColour == "blond")
            hair.GetComponent<SpriteRenderer>().color = new Color(200 / 255f, 178 / 255f, 108 / 255f, 1);
        else if (newColour == "light brown")
            hair.GetComponent<SpriteRenderer>().color = new Color(152 / 255f, 110 / 255f, 51 / 255f, 1);
        else if (newColour == "dark brown")
            hair.GetComponent<SpriteRenderer>().color = new Color(84 / 255f, 48 / 255f, 22 / 255f, 1);
        else if (newColour == "black")
            hair.GetComponent<SpriteRenderer>().color = new Color(0 / 255f, 0 / 255f, 0 / 255f, 1);
        else if (newColour == "green")
            hair.GetComponent<SpriteRenderer>().color = new Color(105 / 255f, 190 / 255f, 58 / 255f, 1);
        else if (newColour == "turquoise")
            hair.GetComponent<SpriteRenderer>().color = new Color(75 / 255f, 238 / 255f, 181 / 255f, 1);
        else if (newColour == "blue")
            hair.GetComponent<SpriteRenderer>().color = new Color(37 / 255f, 114 / 255f, 144 / 255f, 1);
        else if (newColour == "purple")
            hair.GetComponent<SpriteRenderer>().color = new Color(161 / 255f, 75 / 255f, 245 / 255f, 1);
        else if (newColour == "pink")
            hair.GetComponent<SpriteRenderer>().color = new Color(212 / 255f, 63 / 255f, 122 / 255f, 1);

        characterInfo.hairColour = hair.GetComponent<SpriteRenderer>().color;
    }

    public void changerSkinColour(string newColour)
    {
        if (newColour == "green")
            skin.GetComponent<SpriteRenderer>().color = new Color(80 / 255f, 152 / 255f, 48 / 255f, 1);
        else if (newColour == "less green")
            skin.GetComponent<SpriteRenderer>().color = new Color(156 / 255f, 183 / 255f, 87 / 255f, 1);
        else if (newColour == "pale")
            skin.GetComponent<SpriteRenderer>().color = new Color(217 / 255f, 206 / 255f, 129 / 255f, 1);
        else if (newColour == "olive")
            skin.GetComponent<SpriteRenderer>().color = new Color(200 / 255f, 178 / 255f, 108 / 255f, 1);
        else if (newColour == "tan")
            skin.GetComponent<SpriteRenderer>().color = new Color(168 / 255f, 136 / 255f, 91 / 255f, 1);
        else if (newColour == "dark")
            skin.GetComponent<SpriteRenderer>().color = new Color(144 / 255f, 101 / 255f, 69 / 255f, 1);
        else if (newColour == "darker")
            skin.GetComponent<SpriteRenderer>().color = new Color(113 / 255f, 73 / 255f, 52 / 255f, 1);

        characterInfo.skinColour = skin.GetComponent<SpriteRenderer>().color;
    }

    public void goToContainer(string container)
    {
        backButton.SetActive(true);

        categoryContainer.SetActive(false);

        if (container == "eyes")
        {
            eyesContainer.SetActive(true);
        }
        else if (container == "nose")
        {
            noseContainer.SetActive(true);
        }

        else if (container == "mouth")
        {
            mouthContainer.SetActive(true);
        }

        else if (container == "hair")
        {
            hairContainer.SetActive(true);
        }

        else if (container == "hair colour")
        {
            hairColourContainer.SetActive(true);
        }

        else if (container == "skin")
        {
            skinContainer.SetActive(true);
        }

        else if (container == "top")
        {
            topContainer.SetActive(true);
        }

        else if (container == "bottom")
        {
            bottomContainer.SetActive(true);
        }
        else if (container == "hats")
        {
            hatContainer.SetActive(true);
        }

    }

    public void backToCategories()
    {
        backButton.SetActive(false);

        eyesContainer.SetActive(false);
        noseContainer.SetActive(false);
        mouthContainer.SetActive(false); 
        skinContainer.SetActive(false);
        hairContainer.SetActive(false);
        hairColourContainer.SetActive(false);
        topContainer.SetActive(false); 
        bottomContainer.SetActive(false); 
        hatContainer.SetActive(false);

        categoryContainer.SetActive(true);
    }

    public void finished()
    {
        characterInfo.eyes = eyes.GetComponent<SpriteRenderer>().sprite;
        SceneManager.LoadScene("roomTalk");
    }

    public void setTopInt(int i)
    {
        characterInfo.topInt = i;
    }

    public void setBottomInt(int i)
    {
        characterInfo.bottomInt = i;
    }

    public void setHairInt(int i)
    {
        characterInfo.hairInt = i;
    }

    public void setHatInt(int i)
    {
        characterInfo.hatInt = i;
    }

}
