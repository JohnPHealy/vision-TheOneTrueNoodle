using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BrightFlyMovement : MonoBehaviour
{
    public float speed = 3f;
    private GameObject Player;

    public float minDistance = 3f;
    private float range;
    private Vector3 targetPos;
    private Vector3 StartPos;

    private void Start()
    {
       StartPos = transform.position;
       Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        range = Vector2.Distance(transform.position, Player.transform.position);
 
        if (range > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,StartPos,  speed * Time.deltaTime);
        }
 
        if (range < minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position,  -1 * speed * Time.deltaTime);
        }
 
        
    }
}
