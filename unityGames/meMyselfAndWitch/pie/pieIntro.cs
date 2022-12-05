using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pieIntro : MonoBehaviour
{
    public Text speech;
    public GameObject clickToContinue, bakeButton;

    private int count = 1;

    private int matchPoints; // points go up for every matching item between scarecrow and girly

    void Start()
    {
        // choose the speech from the scarecrow dressup
        if (characterInfo.topInt == characterInfo.scarecrowTopInt)
            matchPoints++; 
        if (characterInfo.bottomInt == characterInfo.scarecrowBottomInt)
            matchPoints++;
        if (characterInfo.hatInt == characterInfo.scarecrowHatInt)
            matchPoints++;
        if (characterInfo.hairInt == characterInfo.scarecrowHairInt)
            matchPoints++;

        if (matchPoints == 0)
            speech.text = "Hm.. The scarecrow looks absolutely nothing like me, but she's still a bit cute, I guess.";
        else if (matchPoints == 1 || matchPoints == 2)
            speech.text = "Doesn't look that much like me, but I see a tiny bit of myself in it. Hay is hard to style as hair, so I forgive you.";
        else if (matchPoints == 3)
            speech.text = "Looks like me, but I feel like something is a bit off. Good job anyway.";
        else
            speech.text = "Amazing work! You nailed it! The hay hair style is on point and the outfit is exactly like mine!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (count == 1)
            {
                speech.text = "Time for the next ME-themed activity:) We're gonna bake a pie!";
            }
            else if (count == 2)
            {
                speech.text = "You may be asking: \"How does a pie follow the theme?\" Well, this is why...";
            }
            else if(count == 3)
            {
                speech.text = "We will be hiding a single cherry tomato into the pie.";
            }
            else if (count == 4)
            {
                speech.text = "The tomato will contain what I most love.";
            }
            else if (count == 5)
            {
                speech.text = "The lucky person who eats this cursed tomato will turn into me! What a blessing.";
                clickToContinue.SetActive(false);
                bakeButton.SetActive(true);
            }

            count++;
        }
    }
}
