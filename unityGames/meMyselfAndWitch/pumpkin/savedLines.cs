using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savedLines : MonoBehaviour
{
    public GameObject glowContainer, holeContainer, innerPumpkinContainer, wholeThingContainer;

    public static GameObject drawingGlow, drawingHole, drawingInnerPumpkin, wholeThing;

    public void save()
    {
        drawingGlow = glowContainer;
        drawingHole = holeContainer;
        drawingInnerPumpkin = innerPumpkinContainer;
        wholeThing = wholeThingContainer;

    }
}
