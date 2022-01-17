using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class backpackButton : MonoBehaviour
{
    public bool myHover;


    public Camera cam;

    private float cameraHalfWidth;
    private float cameraHalfHeight;
    private Transform camTrans;

    private void Start()
    {

        cameraHalfHeight = cam.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * cam.aspect;

        camTrans = cam.GetComponent<Transform>();
        myHover = false;
    }

    void Update()
    {

        // right edge of camera (right of backpack) is at camera width + camera position x (and same for y)
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > (cameraHalfWidth + camTrans.position.x - 2.5f) &&
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y > (cameraHalfHeight + camTrans.position.y - 2.5f))
        {
            myHover = true;
        }
        else
        {
            myHover = false;
        }
    }
}
