using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public int levelIndex;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        GameManager.PlayLevel(levelIndex);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("iT workds;");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
