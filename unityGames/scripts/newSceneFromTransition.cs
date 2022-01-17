using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newSceneFromTransition : MonoBehaviour
{

    private void Start()
    {

    }


    // This will be called as an every at the end of my transition animations
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void toHomepage()
    {
        SceneManager.LoadScene("homepage");
    }

}
