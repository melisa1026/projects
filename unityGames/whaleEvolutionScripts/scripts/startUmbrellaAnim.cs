using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUmbrellaAnim : MonoBehaviour
{

    public GameObject umbrella;

    void startUmbrella()
    {
        // start other object's aniamtion
        umbrella.GetComponent<objectAppearAndAnimationStart>().showAnimation();
    }
}
