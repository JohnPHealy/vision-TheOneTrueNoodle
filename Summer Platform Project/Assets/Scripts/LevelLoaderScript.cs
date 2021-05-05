using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    public float TransitionTime = 1f;
    public string PassageWay;
    public float ExitID;
    private static GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadLevel());
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator LoadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        transition.SetTrigger("Start");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(PassageWay, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        var Spawns = GameObject.FindGameObjectsWithTag("Respawn");
        foreach(GameObject SpawnPoint in Spawns)
        {
            if (ExitID == SpawnPoint.GetComponent<SpawnPoints>().SpawnID)
            {
                Player.transform.position = SpawnPoint.transform.position;
                Player.GetComponent<PlayerSpawner>().LastUsedSpawn = SpawnPoint;
            }
        }
        SceneManager.UnloadSceneAsync(currentScene);
    }
}


