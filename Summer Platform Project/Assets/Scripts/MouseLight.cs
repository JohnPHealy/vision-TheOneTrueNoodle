using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MouseLight : MonoBehaviour
{
    public float speed;
    private static bool IsAlive;
    private static bool brightFlyExists;
    
    private GameObject Player;
    private float range;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (!brightFlyExists)
        {
            brightFlyExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        range = Vector2.Distance(transform.position, Player.transform.position);
        
        if (IsAlive == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (Vector3.Distance(targetPos, transform.position) > 20)
            {
                gameObject.transform.position = targetPos;
            }
        }
        else
        {
            if (range < 10)
            {
                StartCoroutine(BrightLightRevival());
            }
        }
    }

    IEnumerator BrightLightRevival()
    {
        Light2D Light = gameObject.GetComponentInChildren<Light2D>();

        for (float i = 0; i < 2; i += 0.01f)
        {
            Light.pointLightInnerRadius = i + 0;
            Light.pointLightOuterRadius = i*2 + 1;
            yield return new WaitForSeconds(0.01f);
        }

        Light.pointLightInnerRadius = 2;
        Light.pointLightOuterRadius = 5;
        IsAlive = true;
    }
}
