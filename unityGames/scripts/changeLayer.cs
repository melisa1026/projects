using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLayer : MonoBehaviour
{
    public SpriteRenderer log;
    public string layerName;
    public void switchLayer()
    {
        log.sortingLayerName = layerName;
    }
}
