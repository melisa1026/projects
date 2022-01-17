using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class homepage : MonoBehaviour
{

    public Animator logoAnimator;
    public Canvas buttons;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(openingLogo());
    }

    public IEnumerator openingLogo()
    {
        yield return new WaitForSeconds(1);

        logoAnimator.enabled = true;
    }

    public IEnumerator endOfLogo()
    {
        logoAnimator.enabled = false;
        yield return new WaitForSeconds(1);
        buttons.enabled = true;

    }

    public void startButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void tutorialButton()
    {
        SceneManager.LoadScene("tutorialPage");
    }
}
