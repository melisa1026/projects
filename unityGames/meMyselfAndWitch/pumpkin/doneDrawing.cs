using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doneDrawing : MonoBehaviour
{

    public GameObject doneButton, undoButton, instructions, lineGenerator, otherLineGenerator, otherOtherlineGenerator, carveAnim, lineContainer, pumpkinSize, nightButton, nextButton;
    public Material innerPumpkinMaterial;
    public GameObject nighttimePump;
    public GameObject lineContainer1, lineContainer2, lineContainer3;
    public savedLines savedLinesScript;

    public void done()
    {
        // get rid of done and undo buttons, and instructions
        // remove line generator
        // poof poof carve animation
        // replace with a more carvy look

        doneButton.SetActive(false);
        undoButton.SetActive(false);
        instructions.SetActive(false);
        lineGenerator.SetActive(false); ;
        otherLineGenerator.SetActive(false);
        otherOtherlineGenerator.SetActive(false);


        StartCoroutine(carve());
    }

    public IEnumerator carve()
    {
        carveAnim.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        pumpkinSize.transform.localScale = new Vector3(1.07f * pumpkinSize.transform.localScale.x, 1.07f * pumpkinSize.transform.localScale.y, 1 * pumpkinSize.transform.localScale.z);
        savedLinesScript.save();

        yield return new WaitForSeconds(1.5f);

        carveAnim.SetActive(false);
        nightButton.SetActive(true);
    }

    public void viewAtNight()
    {
        nightButton.SetActive(false);
        nighttimePump.SetActive(true);
        lineContainer1.SetActive(false);
        nextButton.SetActive(true);
    }

    public void blowOutCandle()
    {
        lineContainer2.SetActive(false);
        lineContainer3.SetActive(false);
    }
}
