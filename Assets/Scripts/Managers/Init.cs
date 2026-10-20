using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public Log Log;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadAllSingletonManagers();



        StartGame();


    }

    private void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void LoadAllSingletonManagers()
    {
        Log.AddToLog("Loading Managers...");



        Log.AddToLog("Loading Scenes...");


    }
}
