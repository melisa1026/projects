using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectAppearAndAnimationStart : MonoBehaviour
{
    //sprite renderer that I'm making visible
    public SpriteRenderer rend;

    // animator that I'm adjusting
    public Animator anim;
    public string state;

    private void Start()
    {
        // set the sprite renderer being used to the current game object's sprite renderer component
        rend = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void showAnimation()
    {
        // restart the animation
        anim.Play(state, -1, 0f);

        // switch visibility
        rend.enabled = !rend.enabled;
    }

}
