using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    // button location (min x, max x, min y, max y)
    public Vector4 location;

    public bool isRightPoint, isLeftPoint, isPoint;
    public bool myHover;
    private Vector3 mouseSpot;

    private void Update()
    {
        checkForHover();
    }

    // checks if the mouse if hovered over the button
    private void checkForHover()
    {
        mouseSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // if the mouse if over the button, mark as hovered
        if (mouseSpot.x > location.x && mouseSpot.x < location.y &&
            mouseSpot.y > location.z && mouseSpot.y < location.w)
        {
            myHover = true;
        }
        else
        {
            myHover = false;
        }

    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void deleteButton()
    {
        if(SceneManager.GetActiveScene().name == "InnerMall")
            staticVariables.vendingButtonActive = false;
        else if (SceneManager.GetActiveScene().name == "OuterMall")
            staticVariables.newsButton = false;
        else if(SceneManager.GetActiveScene().name == "PlainTees")
            staticVariables.materialButtons = false;

        myHover = false;
        gameObject.SetActive(false);
    }

    public void returnToScene()
    {
        SceneManager.LoadScene(staticVariables.runningScene);
    }

}

// Using IsPointerOverGameObject() returned true when the mouse was over ANY button and therefore marked that every button was hovered over whenever
// one was. This made the pointer always go the same way

/* public void Update()
    {
        // check if any other scripts are hovered over to avoid switching all the variables to false
        otherHover = false;
        for (int i = 0; i < otherButtons.Length; i++)
        {
            if (otherButtons[i].myHover == true)
            {
                otherHover = true;
            }
        }


        checkForHover();
    }

    public void checkForHover()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            myHover = true;

            if (isRightPoint)
            {
                cursorShape.mousePointsRight = true;
                cursorShape.mousePointsLeft = false;
                cursorShape.mousePoints = false;
                Debug.Log("Coraline");
            }
            else if (isLeftPoint)
            {
                cursorShape.mousePointsLeft = true;
                cursorShape.mousePointsRight = false;
                cursorShape.mousePoints = false;
            }
            else if (isPoint)
            {
                cursorShape.mousePoints = true;
                cursorShape.mousePointsRight = false;
                cursorShape.mousePointsLeft = false;
                Debug.Log("Helloooooo");
            }
            
        }
        else if (!otherHover)
        {
            cursorShape.mousePointsRight = false;
            cursorShape.mousePointsLeft = false;
            cursorShape.mousePoints = false;
            Debug.Log("Reset");
        }
    } */
