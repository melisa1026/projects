using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script sets the character up at the beggining of the scene

public class setScarecrow : MonoBehaviour
{

    public GameObject top, bottom, hair, hat;

    // Start is called before the first frame update
    void Start()
    {
        if (characterInfo.top != null)
            top.GetComponent<SpriteRenderer>().sprite = characterInfo.scarecrowTop;
        if (characterInfo.bottom != null)
            bottom.GetComponent<SpriteRenderer>().sprite = characterInfo.scarecrowBottom;
        if (characterInfo.hair != null)
            hair.GetComponent<SpriteRenderer>().sprite = characterInfo.scarecrowHair;
        if (characterInfo.hat != null)
            hat.GetComponent<SpriteRenderer>().sprite = characterInfo.scarecrowHat;
    }
}
