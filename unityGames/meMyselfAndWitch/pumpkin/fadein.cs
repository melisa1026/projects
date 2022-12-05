using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadein : MonoBehaviour
{
    public GameObject blackScreen;

    void Start()
    {
        StartCoroutine(fade());
    }

    public IEnumerator fade()
    {
        blackScreen.SetActive(true);

        for (int j = 50; j > 0; j--)
        {
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, j / 50f);
            yield return new WaitForSeconds(0.05f);
        }

        blackScreen.SetActive(false);
    }
}
