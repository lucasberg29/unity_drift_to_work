using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public TextMeshProUGUI goToWorkText;

    public GameObject pauseMenu;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //goToWorkText = GameObject.Find("Canvas/GoToWorkText").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeText()
    {
        if (goToWorkText != null)
        {
            Color textColor = goToWorkText.color;

            for (float alpha = 1.0f; alpha >= 0; alpha -= 0.45f * Time.deltaTime)
            {
                textColor.a = alpha;
                goToWorkText.color = textColor;
                yield return null;
            }
        }
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void RemoveText()
    {
        goToWorkText.text = "";
    }
}
