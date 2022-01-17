using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shark : MonoBehaviour
{
    public Animator anim;
    public PlayerControls1 whale;

    public void eat()
    {
        // switch to the opening mouth animation
        anim.Play("sharkEat", -1, 0f);
    }

    // here the shark swims away
    IEnumerator afterOpenMouth()
    {

        Destroy(anim);
        // needs to move -21 in 100 movements
        // so 50 (1.2f, 0, 0) translation loops
        Vector3 transformDir = new Vector3(-1.2f, 0, 0);
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.05f);
            transform.Translate(transformDir);

            if (transform.position.x < -4 && transform.position.x > -5.4f)
            {
                whale.whaleDisappear();
            }
        }
    }
}
