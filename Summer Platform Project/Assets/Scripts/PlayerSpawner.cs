using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private static bool playerExists;
    public GameObject LastUsedSpawn;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
