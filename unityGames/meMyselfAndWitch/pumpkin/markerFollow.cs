using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerFollow : MonoBehaviour
{

    public GameObject marker;
    public Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        marker.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    public void finishDrawing()
    {
        marker.SetActive(false);
    }
}
