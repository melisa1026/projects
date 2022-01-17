using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlyAway : MonoBehaviour
{
    public Text outroText;
    public Canvas canvas;

    private void Start()
    {
        // start at size: (0.59088, 0.59088, 0.59088)
        // start at position (-4.94, 0, 0)
        transform.position = (new Vector3(-4.94f, 0, 0));
        transform.localScale = new Vector3(0.59088f, 0.59088f, 0.59088f);

        // start moving
        StartCoroutine(flyZoomedIn());
    }

    public IEnumerator flyZoomedIn()
    {
        // needs to go from (-4.94, 0, 0) to (9.33, 9.88, 0) within 100
        // moves vector or (14.27, 9.88, 0)
        // so for each loop, move (0.1427, 0.0988, 0)

        Vector3 movePerLoop = new Vector3(0.1427f, 0.0988f, 0);

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.03f);
            transform.Translate(movePerLoop);
        }

        // next flying scene
        StartCoroutine(flyZoomedOut());

    }

    public IEnumerator flyZoomedOut()
    {
        // set new position
        transform.localScale = new Vector3(0.2512068f, 0.2512068f, 0.2512068f);
        transform.position = (new Vector3(-6.32f, -2.88f, 0));

        // move to position (2.67, 7.49, 0)
        // total move: (9, 10.37, 0)
        // over 100 loops, each is (0.09, 0.1037)

        Vector3 movePerLoop = new Vector3(0.09f, 0.1037f, 0);

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.03f);
            transform.Translate(movePerLoop);
        }

        StartCoroutine(outroWriting());

    }

    public IEnumerator outroWriting()
    {

        yield return new WaitForSeconds(1);

        // set text
        outroText.text = "Your whale has now become the most evolved species on earth.";

        // make text and background to it visible
        canvas.enabled = true;

        // wait a few seconds then change text
        yield return new WaitForSeconds(3);
        outroText.text = "It has decided to look for more,\n";

        yield return new WaitForSeconds(3);
        outroText.text = "It has decided to look for more,\nsee what else is out there...";

        yield return new WaitForSeconds(3);
        outroText.text = "Goodbye whale <3";

        yield return new WaitForSeconds(3);
        outroText.text = "Have fun exploring the universe:)";

        yield return new WaitForSeconds(3);
        canvas.enabled = false;

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("homepage");
    }
}
