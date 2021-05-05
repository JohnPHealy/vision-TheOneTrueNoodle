using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoubleJump : MonoBehaviour
{
    public bool playerCollectUpgrade;
    private GameObject player;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerCollectUpgrade = true;
            other.GetComponent<PlayerMovement>().unlockedDoubleJump = playerCollectUpgrade;
            Destroy(gameObject);
        }
    }
}
