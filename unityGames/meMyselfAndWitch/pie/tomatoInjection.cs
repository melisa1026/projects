using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tomatoInjection : MonoBehaviour
{
    public GameObject flasks, tomato, syringe, text, blackScreen;

    public void inject()
    {
        text.SetActive(false);
        flasks.SetActive(false);

        // change tomato position and size
        StartCoroutine(injectIE());
    }

    public IEnumerator injectIE()
    {
        Vector3 movePerFrame = new Vector3((-0.6f - tomato.transform.position.x) / 50, (-2.47f - tomato.transform.position.y) / 50, 0);
        for(int i = 0; i < 50; i++)
        {
            tomato.transform.Translate(movePerFrame, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

        syringe.SetActive(true);

        yield return new WaitForSeconds(5);

        blackScreen.SetActive(true);

        for (int i = 0; i < 50; i++)
        {
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, i / 50f);
            yield return new WaitForSeconds(0.05f);
        }

        SceneManager.LoadScene("pie");
    }
}
