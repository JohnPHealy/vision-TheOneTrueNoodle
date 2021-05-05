using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public string song;
    private static bool playing;

    void Start()
    {
        if (playing == false)
        {
            FindObjectOfType<AudioManager>().Play(song);
            playing = true;
        }
    }
}

