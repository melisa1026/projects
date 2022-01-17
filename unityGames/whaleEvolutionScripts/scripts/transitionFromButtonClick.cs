using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionFromButtonClick : MonoBehaviour
{
    public Animator anim;
    public Sprite loseTail;
    public Sprite yellowTongue;
    public Sprite eyebrows;
    public SpriteRenderer player;
    public string block1 = "3-eyebrows";
    public string block2 = "3-tail";
    public string block3 = "3-tongue";

    public void wrongWhaleTransition(string state)
    {
        anim.Play(state, -1, 0f);

        if (state.Equals(block1))
        {
            player.sprite = eyebrows;
        }

        else if (state.Equals(block2))
        {
            player.sprite = loseTail;
        }

        else if (state.Equals(block3));
        {
            player.sprite = yellowTongue;
        }
    }

    public void destroyAnimator()
    {
        Destroy(anim);
    }
}
