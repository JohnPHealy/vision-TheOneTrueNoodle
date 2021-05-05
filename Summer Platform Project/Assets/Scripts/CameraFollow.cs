using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject Player;
    private GameObject BoundingBox;
    private static bool cameraExists;
    
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        BoundingBox = GameObject.FindGameObjectWithTag("BoundingBox");
        Collider2D Box = BoundingBox.GetComponent<CompositeCollider2D>();
        var vcam = GetComponent<CinemachineVirtualCamera>();
        var vcamBounds = GetComponent<CinemachineConfiner>();
        
        
        vcam.Follow = Player.transform;
        vcamBounds.m_BoundingShape2D = Box;
    }
}
