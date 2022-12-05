using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{

    public GameObject linePrefab, lineContainer;

    Line activeLine;

    bool mouseInRange;

    Vector3 mousePos;


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePos.x > -3.95f && mousePos.x < 3.7f && mousePos.y > -3.34f && mousePos.y < 3)
        {
            mouseInRange = true;
        }
        else
        {
            mouseInRange = false;
        }


        if (Input.GetMouseButtonDown(0) && mouseInRange)
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();

            newLine.transform.parent = lineContainer.transform;
        }

        if (Input.GetMouseButtonUp(0) || !mouseInRange)
        {
            activeLine = null;
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.updateLine(mousePos);
        }
    }

    public void undo()
    {
        if (lineContainer.transform.childCount != 0)
        {
            (lineContainer.transform.GetChild(lineContainer.transform.childCount - 1).gameObject).SetActive(false); ;
        }
    }
}
