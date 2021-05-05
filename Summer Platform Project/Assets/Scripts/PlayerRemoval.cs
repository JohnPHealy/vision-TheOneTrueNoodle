using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRemoval : MonoBehaviour
{
    private GameObject Player;
    private GameObject BrightFly;
    
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        BrightFly = GameObject.FindGameObjectWithTag("Mouse Fly");
        Destroy(Player);
        Destroy(BrightFly);
    }
}
