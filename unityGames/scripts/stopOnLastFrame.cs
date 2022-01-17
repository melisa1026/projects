using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopOnLastFrame : MonoBehaviour
{
    public Animator anim;                   // animator to delete
    public Sprite lastFrame;                // frame to stop on
    public SpriteRenderer bgSprite;         // the sprite renderer of the object to change

    void stop()
    {
        bgSprite.sprite = lastFrame;
        Destroy(anim);
    }
}
