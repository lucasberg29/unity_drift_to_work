using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProp : MonoBehaviour
{
    [Header ("Model of the object whole")]
    public GameObject objectWhole;
    [Header("Model of the object cracked")]
    public GameObject objectCracked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Player")
        {
            StartDestruction();
        }
    }

    public void StartDestruction()
    {
        objectCracked.SetActive (true);
        objectWhole.SetActive (false);
    }
}
