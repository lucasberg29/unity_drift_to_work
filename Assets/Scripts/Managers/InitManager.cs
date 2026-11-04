using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : MonoBehaviour
{
    public LogManager LogManager;


    void Start()
    {
        LoadAllSingletonManagers();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Starting game!");
            StartGame();
        }
    }

    private void LoadAllSingletonManagers()
    {
        LogManager.AddToLog("Loading Managers...");
        LogManager.AddToLog("Loading Scenes...");
    }
}
