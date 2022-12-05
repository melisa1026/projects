using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script sets the character up at the beggining of the scene

public class setCharacter : MonoBehaviour
{

    public GameObject eyes, nose, mouth, top, bottom, hair, hat, skin;

    // Start is called before the first frame update
    void Start()
    {
        if(characterInfo.eyes != null)
            eyes.GetComponent<SpriteRenderer>().sprite = characterInfo.eyes;
        if(characterInfo.nose != null)
            nose.GetComponent<SpriteRenderer>().sprite = characterInfo.nose;
        if(characterInfo.mouth != null)
            mouth.GetComponent<SpriteRenderer>().sprite = characterInfo.mouth;
        if(characterInfo.top != null)
            top.GetComponent<SpriteRenderer>().sprite = characterInfo.top;
        if(characterInfo.bottom != null)
            bottom.GetComponent<SpriteRenderer>().sprite = characterInfo.bottom;
        if(characterInfo.hair != null)
            hair.GetComponent<SpriteRenderer>().sprite = characterInfo.hair;
        if(characterInfo.hat != null)
            hat.GetComponent<SpriteRenderer>().sprite = characterInfo.hat;
        if(characterInfo.skinColour != null)
            skin.GetComponent<SpriteRenderer>().color = characterInfo.skinColour;
        if(characterInfo.hairColour != null)
            hair.GetComponent<SpriteRenderer>().color = characterInfo.hairColour;
    }
}
