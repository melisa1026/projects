using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makePie : MonoBehaviour
{
    public GameObject sugarIngredient, saltIngredient, berriesIngredient, sugar, berries, mixedPie, pieTin, bakedPie, tomato, saltBackground, saltGrains, instructions, finishButton;
    public GameObject mixButton, blackScreen;
    private bool sugarAdded = false, saltAdded = false, berriesAdded = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addSugar()
    {
        sugarAdded = true;

        sugarIngredient.SetActive(false);
        sugar.SetActive(true);

        if (saltAdded && berriesAdded)
        {
            mixButton.SetActive(true);
        }
    }

    public void addSalt()
    {
        StartCoroutine(shakeSalt());
    }

    public IEnumerator shakeSalt()
    {
        // spin salt
        for(int i = 0; i < 50; i++)
        {
            saltIngredient.transform.Rotate(0, 0, 4f);
            yield return new WaitForSeconds(0.015f);
        }

        saltGrains.SetActive(true);

        // shake
        for (int i = 0; i < 15; i++)
        {
            saltIngredient.transform.Rotate(0, 0, -4f);
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 15; i++)
        {
            saltIngredient.transform.Rotate(0, 0, 4f);
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 15; i++)
        {
            saltIngredient.transform.Rotate(0, 0, -4f);
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 10; i++)
        {
            saltIngredient.transform.Rotate(0, 0, 4f);
            yield return new WaitForSeconds(0.02f);
        }

        saltGrains.SetActive(false);

        yield return new WaitForSeconds(0.3f);


        saltAdded = true;

        saltIngredient.SetActive(false);
        saltBackground.SetActive(false);

        if (berriesAdded && sugarAdded)
        {
            mixButton.SetActive(true);
        }
    }

    public void addBerries()
    {
        berriesAdded = true;

        berriesIngredient.SetActive(false);
        berries.SetActive(true);

        if(saltAdded && sugarAdded)
        {
            mixButton.SetActive(true);
        }
    }

    public void mix()
    {
        mixButton.SetActive(false);
        berries.SetActive(false);
        sugar.SetActive(false);
        instructions.SetActive(false);
        mixedPie.SetActive(true);
    }

    public void finishMixing()
    {
         mixedPie.GetComponent<Animator>().enabled = false;
        StartCoroutine(finishMixingIE());
    }

    public IEnumerator finishMixingIE()
    {
        StartCoroutine(tomatoFall());

        yield return new WaitForSeconds(1.3f);

        blackScreen.SetActive(true);

        for(int i = 0; i < 50; i++)
        {
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, i / 50f);
            yield return new WaitForSeconds(0.05f);
        }

        mixedPie.SetActive(false);
        bakedPie.SetActive(true);
        yield return new WaitForSeconds(0.5f);


        for (int j = 50; j > 0; j--)
        {
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, j / 50f);
            yield return new WaitForSeconds(0.05f);
        }


        blackScreen.SetActive(false);

        finishButton.SetActive(true);
    }

    public IEnumerator tomatoFall()
    {
        for(int i = 0; i < 50; i++)
        {
            tomato.transform.Translate(0, -6/50f, 0);
            yield return new WaitForSeconds(0.03f);
        }
        tomato.SetActive(false);
    }
}
