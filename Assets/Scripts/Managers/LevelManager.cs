using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.SceneManagement.SceneManager;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 0;
    private int numOfClicks = 0;
    private int numOfRecentTouches = 0;
    private float timer = 2.0f;

    void Update()
    {
        timer = timer - 1 * Time.deltaTime;

        numOfRecentTouches = Input.touchCount;

        if (numOfRecentTouches > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ++numOfClicks;
            }
        }

        if (numOfClicks > 4)
        {
            LoadScene("MainMenu");
        }

        if(timer < 0)
        {
            timer = 2;
            numOfClicks = 0;
        }
    }
}
