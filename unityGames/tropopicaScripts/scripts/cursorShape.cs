using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class cursorShape : MonoBehaviour
{
    public GameObject player;

    public Texture2D greenArrow;
    public Texture2D yellowArrow;
    public Texture2D blueArrow;
    public Texture2D greenArrowLeft;
    public Texture2D yellowArrowLeft;
    public Texture2D blueArrowLeft;
    public Texture2D pointing, pointingRight, pointingLeft;

    private Vector3 mouseSpot;
    private Vector3 playerSpot;
    public buttons[] butts;         // to indicate if a button is hovered over
    public movingCharacters[] charButts;
    public backpackButton backpack;


    [Range(0,2)]
    public float xOffset = 1.3f;

    public static bool mousePointsLeft, mousePointsRight, mousePoints;

    private bool isHover; // becomes true if any buttons are hovered on

    private void Update()
    {
        isHover = false;
        for (int i = 0; i < butts.Length; i++)
        {
            if (butts[i].myHover)
            {
                isHover = true;
                if (butts[i].isPoint)
                {
                    mousePoints = true;
                    mousePointsRight = false;
                    mousePointsLeft = false;
                }
                else if (butts[i].isRightPoint)
                {
                    mousePoints = false;
                    mousePointsRight = true;
                    mousePointsLeft = false;
                }
                else if (butts[i].isLeftPoint)
                {
                    mousePoints = false;
                    mousePointsRight = false;
                    mousePointsLeft = true;
                }
            }
        }
        if (charButts != null)
        {
            for (int i = 0; i < charButts.Length; i++)
            {
                if (charButts[i].myHover)
                {
                    isHover = true;
                    mousePoints = true;
                    mousePointsRight = false;
                    mousePointsLeft = false;
                }
            }
        }
        if (backpack.myHover)
        {
            isHover = true;
            mousePoints = true;
            mousePointsRight = false;
            mousePointsLeft = false;
        }

        if(!isHover)
        {
            mousePoints = false;
            mousePointsRight = false;
            mousePointsLeft = false;
        }

        mouseSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerSpot = player.transform.position;

        if(mousePoints)
            setCursor(pointing);
        else if (mousePointsRight)
            setCursor(pointingRight);
        else if (mousePointsLeft)
            setCursor(pointingLeft);
        // cursor image
        // jump level
        else if (mouseSpot.y > playerSpot.y + 3.0f)
        {
            if (mouseSpot.x > (playerSpot.x-xOffset))
                setCursor(greenArrow);
            else
                setCursor(greenArrowLeft);
        }
        // roll level
        else if (mouseSpot.y < playerSpot.y - 0.2f)
        {
            if (mouseSpot.x > (playerSpot.x - xOffset))
                setCursor(yellowArrow);
            else
                setCursor(yellowArrowLeft);
        }
        // ground level
        else
        {
            if (mouseSpot.x > playerSpot.x - xOffset)
                setCursor(blueArrow);
            else
                setCursor(blueArrowLeft);
        }

    }
    public void setCursor(Texture2D cursorImage)
    {
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }  
}
