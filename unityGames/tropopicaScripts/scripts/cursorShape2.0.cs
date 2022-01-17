using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorShape2 : MonoBehaviour
{
    public GameObject player;

    public Texture2D greenArrow;
    public Texture2D yellowArrow;
    public Texture2D blueArrow;
    public Texture2D greenArrowLeft;
    public Texture2D yellowArrowLeft;
    public Texture2D blueArrowLeft;
    private Vector3 mouseSpot;
    private Vector3 playerSpot;


    private void Update()
    {
        mouseSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerSpot = player.transform.position;

        // cursor image
        if (mouseSpot.y > playerSpot.y + 3.0f)
        {
            if (mouseSpot.x > playerSpot.x)
                setCursor(greenArrow);
            else
                setCursor(greenArrowLeft);
        }
        else if (mouseSpot.y < playerSpot.y - 0.2f)
        {
            if (mouseSpot.x > playerSpot.x)
                setCursor(yellowArrow);
            else
                setCursor(yellowArrowLeft);
        }
        else
        {
            if (mouseSpot.x > playerSpot.x)
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
