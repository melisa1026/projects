using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class buttonControl : MonoBehaviour
{

    public buttons buttonToDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        // !!!!!!!!!!!!!!!!!!!!!!!! when editing this also edit the buttons script under deleteButton()
        if (SceneManager.GetActiveScene().name == "InnerMall" && !staticVariables.vendingButtonActive)
        {
            buttonToDeactivate.GetComponent<buttons>().deleteButton();
        }
        else if (SceneManager.GetActiveScene().name == "OuterMall" && !staticVariables.newsButton)
        {
            buttonToDeactivate.GetComponent<buttons>().deleteButton();
        }
        else if (SceneManager.GetActiveScene().name == "PlainTees" && !staticVariables.materialButtons)
        {
            buttonToDeactivate.GetComponent<buttons>().deleteButton();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
