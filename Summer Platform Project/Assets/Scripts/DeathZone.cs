using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DeathZone : MonoBehaviour
{
    public GameObject SpawnPoint;
    private static GameObject Brightfly;

    private void Start()
    {
        Brightfly = GameObject.FindGameObjectWithTag("Mouse Fly");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<PlayerSpawner>().LastUsedSpawn == null)
            {
                other.transform.position = SpawnPoint.transform.position;
            }
            else
            {
                SpawnPoint = other.GetComponent<PlayerSpawner>().LastUsedSpawn;
                other.transform.position = SpawnPoint.transform.position;
            }
        }
    }
}
