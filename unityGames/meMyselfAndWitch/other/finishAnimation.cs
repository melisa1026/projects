using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishAnimation : MonoBehaviour
{
    public GameObject syringe, witch, explosion, finishButton;
    public Animator anim;

    public void destroyAnim()
    {
        syringe.SetActive(false);
    }

    public void stopAnim()
    {
        anim.enabled = false;
    }

    public void startWitchAnim()
    {
        witch.SetActive(true);
        explosion.GetComponent<Animator>().enabled = true;
        explosion.SetActive(true);
        anim.gameObject.SetActive(false);
        finishButton.SetActive(true);
    }
}
