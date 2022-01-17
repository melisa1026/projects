using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collectObject : MonoBehaviour
{
    public GameObject card, collectedObj;
    public Text objectName;
    public Camera cam;
    private float camHalfWidth, camHalfHeight;

    public void collect()
    {
        StartCoroutine(collectIE());

        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;
    }

    public IEnumerator collectIE()
    {
        
        Transform cardTrans = card.GetComponent<Transform>();
        Transform camTrans = cam.GetComponent<Transform>();
        cardTrans.position = new Vector3(camTrans.position.x, camTrans.position.y, cardTrans.position.z);

        SpriteRenderer cardRend = card.GetComponent<SpriteRenderer>();
        SpriteRenderer objRend = collectedObj.GetComponent<SpriteRenderer>();

        cardRend.enabled = true;
        objRend.enabled = true;
        objectName.enabled = true;


        Transform trans = card.GetComponent<Transform>();
        trans.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        // spin and scale the card to be in the middle big
        for(int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(0.001f);
            trans.localScale = new Vector3(trans.localScale.x + 0.2f, trans.localScale.y + 0.2f, trans.localScale.z);
            trans.Rotate(0, 0, 12);
        }

        yield return new WaitForSeconds(1);

        // move the card to the bag ( top corner)
        // target: camera's max width and height - about 0.5 in both x and y
        // find the distance between current spot and target spot per animation frame (30 frames)


        Vector3 distPerFrame = new Vector3((camHalfWidth - 1)/30, (camHalfHeight - 1)/30, 0);

        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.001f);
            trans.Translate(distPerFrame);
            trans.localScale = new Vector3(trans.localScale.x - 0.4f, trans.localScale.y - 0.4f, trans.localScale.z);
        }

        // remove the object from the scene
        card.SetActive(false);

        /*if (SceneManager.GetActiveScene().name == "PopFashion")
        {
            staticVariables.shirtNet = true;
        }*/
        
    }

    public void markCollectedCard(string collectedCard)
    {
        if (collectedCard == "newspaper")
            staticVariables.newspaper = true;
        else if (collectedCard == "coins")
            staticVariables.coins = true;
        else if (collectedCard == "shirtNet")
            staticVariables.shirtNet = true;
        else if (collectedCard == "stick")
            staticVariables.stick = true;
        else if (collectedCard == "fabrics")
            staticVariables.fabrics = true;
        else if (collectedCard == "coralSnake")
            staticVariables.coralSnake = true;
        else if (collectedCard == "purpleSnake")
            staticVariables.purpleSnake = true;
        else if (collectedCard == "blackYellowSnake")
            staticVariables.blackTellowSnake = true;
        else if (collectedCard == "mouse")
            staticVariables.mouse = true;
        else if (collectedCard == "waterPump")
            staticVariables.waterPump = true;
    }
}
