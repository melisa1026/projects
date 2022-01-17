using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVariables : MonoBehaviour
{
    public static string player, opponent;

    private void Start()
    {
        if (player == null)
            player = "melisa";
        if (opponent == null)
            opponent = "sonya";
    }
}
