using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scarecrowCustom : MonoBehaviour
{

    public GameObject hair, top, bottom, hat; // character parts
    public GameObject categoryContainer, hairContainer, topContainer, bottomContainer, hatContainer; // the empty game objects that contain the option menus for each customizable part
    public GameObject backButton;                   

    // Start is called before the first frame update
    void Start()
    {

    }

    public void changeHair(Sprite newHair)
    {
        hair.GetComponent<SpriteRenderer>().sprite = newHair;
        characterInfo.scarecrowHair = newHair;
    }

    public void changeTop(Sprite newTop)
    {
        top.GetComponent<SpriteRenderer>().sprite = newTop;
        characterInfo.scarecrowTop = newTop;
    }

    public void changeBottom(Sprite newBottom)
    {
        bottom.GetComponent<SpriteRenderer>().sprite = newBottom;
        characterInfo.scarecrowBottom = newBottom;
    }

    public void changeHat(Sprite newHat)
    {
        hat.GetComponent<SpriteRenderer>().sprite = newHat;
        characterInfo.scarecrowHat = newHat;
    }

    public void goToContainer(string container)
    {
        backButton.SetActive(true);

        categoryContainer.SetActive(false);


        if (container == "hair")
        {
            hairContainer.SetActive(true);
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

        hairContainer.SetActive(false);
        topContainer.SetActive(false); 
        bottomContainer.SetActive(false); 
        hatContainer.SetActive(false);

        categoryContainer.SetActive(true);
    }


    public void setCrowTopInt(int i)
    {
        characterInfo.scarecrowTopInt = i;
    }

    public void setCrowBottomInt(int i)
    {
        characterInfo.scarecrowBottomInt = i;
    }

    public void setCrowHairInt(int i)
    {
        characterInfo.scarecrowHairInt = i;
    }

    public void setCrowHatInt(int i)
    {
        characterInfo.scarecrowHatInt = i;
    }
}
