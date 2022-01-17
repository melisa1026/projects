using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLogAnim : MonoBehaviour
{

    public GameObject log;

    void startLog()
    {
        // start other object's aniamtion
        log.GetComponent<objectAppearAndAnimationStart>().showAnimation();
    }
}
