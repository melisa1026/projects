using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openFirstScene : MonoBehaviour
{
    static bool gameJustOpened = true;

    // Start is called before the first frame update
    void Start()
    {
        if (gameJustOpened == true)
        {
            gameJustOpened = false;
            SceneManager.LoadScene("homepage");
        }
    }
}
