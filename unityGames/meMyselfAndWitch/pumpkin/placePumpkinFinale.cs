using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placePumpkinFinale : MonoBehaviour
{
    public GameObject pumpkinContainer;
    public Sprite pumpkinSprite;

    public void Start()
    {
        if (savedLines.wholeThing != null)
        {
            savedLines.wholeThing.GetComponent<dontDestroy>().enabled = false;
            GameObject pumpkin = Instantiate(savedLines.wholeThing, pumpkinContainer.transform);

            for (int i = 0; i < pumpkin.transform.childCount; i++)
            {
                pumpkin.transform.GetChild(i).gameObject.SetActive(true);
            }

            pumpkin.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = pumpkinSprite;
        }
    }
}
 