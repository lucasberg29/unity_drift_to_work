using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static int currentLevel = 0;

    private void Awake()
    {
        Instance = this;

        PlayerPrefs.SetString("Level1", "Unlocked");
        PlayerPrefs.SetString("Level2", "Locked");
        PlayerPrefs.SetString("Level1", "Locked");
    }

    public static void StartGame()
    {
        LoadScene("LevelSelection");
        LevelManager.currentLevel = 1;
    }

    public static void PlayLevel(int level)
    {
        LoadScene(level);
        LevelManager.currentLevel = level;
    }

    public static void Defeat()
    {
        Debug.Log("GAME OVER");

        Ui.instance.ShowPauseMenu();

        Time.timeScale = 0;
    
    }

    public static void ReloadCurrentLevel()
    {

    }
}
