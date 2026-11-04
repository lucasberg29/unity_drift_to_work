using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogManager : MonoBehaviour, IManager
{
    public float logDuration = 5f;

    private Queue<string> logQueue = new Queue<string>();

    GameObject logPrefab;

    #region Private Methods

    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToLog(string message)
    {
        GameObject log = new GameObject("LogMessage");
        log.transform.parent = transform;

        TextMeshProUGUI logMessage = log.AddComponent<TextMeshProUGUI>();
        logMessage.text = message;

        Destroy(log, logDuration);
    }

    public void NewScene()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateManager()
    {
        throw new System.NotImplementedException();
    }

    public void RestartManager()
    {
        throw new System.NotImplementedException();
    }
}
