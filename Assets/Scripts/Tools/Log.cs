using TMPro;
using UnityEngine;

public class Log : MonoBehaviour
{
    public float logDuration = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
}
