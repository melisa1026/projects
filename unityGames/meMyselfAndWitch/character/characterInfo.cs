using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterInfo : MonoBehaviour
{

    public static Sprite eyes, nose, mouth, top, bottom, hair, hat;
    public static int topInt = 4, bottomInt = 3, hairInt = 6, hatInt = 5;
    public static Color hairColour, skinColour;
    public static string witchName; 

    public static Sprite scarecrowTop, scarecrowBottom, scarecrowHair, scarecrowHat; 
    public static int scarecrowTopInt = 2, scarecrowBottomInt = 3, scarecrowHairInt = 6, scarecrowHatInt = 5;

    public InputField inputField;

    public void setWitchName()
    {
        witchName = inputField.text;
    }
}
