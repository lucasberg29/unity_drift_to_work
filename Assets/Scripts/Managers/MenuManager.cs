using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        LoadScene("Level1");
        LevelManager.currentLevel = 1;
    }
}
