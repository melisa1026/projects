using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeaftervideoplays : MonoBehaviour
{
    // use object that i want to start an animation of after deleting current animation
    public GameObject whaleSwimVid;
    public GameObject secondAnimation;

    public SpriteRenderer rend;
    public Animator animToEnable;

    public GameObject yellowFlash;

    private void Start()
    {
        rend = this.gameObject.GetComponent<SpriteRenderer>();
    }
    void destroyObject()
    {

        if (rend.enabled == true)
        {
            // finish current animation
            Destroy(gameObject);

            // start other object's aniamtion
            whaleSwimVid.GetComponent<objectAppearAndAnimationStart>().showAnimation();
        }
    }

    void startSecondAnimation()
    {
        secondAnimation.GetComponent<objectAppearAndAnimationStart>().showAnimation();
    }

    void destroyObjectButDontStartAnything()
    {
        Destroy(gameObject);
    }


    public void activateAnimator()
    {
        animToEnable.enabled = true;
    }


    public void removeYellowFlashComponent()
    {
        Destroy(yellowFlash);
    }
}

