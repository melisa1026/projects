using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{

    public LineRenderer lineRend;
    List<Vector2> points;

    void setPoint(Vector2 point)
    {
        // add a point to the list
        points.Add(point);

        // update the number of verticies on the line
        lineRend.positionCount = points.Count;

        // set a point position
        lineRend.SetPosition(points.Count - 1, point);
    }

    public void updateLine(Vector2 position)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            setPoint(position);
            return;
        }

        if(Vector2.Distance(points.Last(), position) > 0.1f)
        { 
            setPoint(position);
        }
    }
}
