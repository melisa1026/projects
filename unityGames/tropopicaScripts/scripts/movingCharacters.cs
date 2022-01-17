using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCharacters : MonoBehaviour
{
    public float minY, maxY, buttonHalfWidth;
    private Vector3 mouseSpot;
    public bool myHover = false;

    // Update is called once per frame
    void Update()
    {
        mouseSpot = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;

        if (mouseSpot.x > transform.position.x - buttonHalfWidth && mouseSpot.x < transform.position.x + buttonHalfWidth
            && mouseSpot.y > minY && mouseSpot.y < maxY)
        {
            myHover = true;
        }
        else 
        {
            myHover = false;
        }
    }
}
