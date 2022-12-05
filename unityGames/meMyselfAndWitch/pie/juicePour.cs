using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juicePour : MonoBehaviour
{

    public GameObject pouredLiquid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void poutNotIE()
    {
        StartCoroutine(pour());
    }

    public IEnumerator pour()
    {
        // first put it to a higher layer
        // then put it pouring spot (43.2, -14.6, 0)
        // then pour
        // put back
        // put it back to original layer

        //GetComponent<SpriteRenderer>().sortingOrder = 10;

        Vector3 movePerFrame = new Vector3((3.18f - transform.position.x) / 50f, (-0.2f - transform.position.y) / 50f, 0);
        for(int i = 0; i < 50; i++)
        {
            transform.Translate(movePerFrame, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 50; i++)
        {
            transform.Rotate(0, 0, -65/50f, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

        pouredLiquid.SetActive(true);

        yield return new WaitForSeconds(2);

        pouredLiquid.SetActive(false);

        for (int i = 0; i < 50; i++)
        {
            transform.Rotate(0, 0, 65 / 50f, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 50; i++)
        {
            transform.Translate(-1 * movePerFrame, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

    }
}
