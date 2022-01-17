using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyAudio : MonoBehaviour
{
    static bool audioAlreadyPlaying;
    private GameObject[] music;

    private void Start()
    {
        music = GameObject.FindGameObjectsWithTag("gameMusic");
        if (music.Length >= 2)
        {
            Destroy(music[1]);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
