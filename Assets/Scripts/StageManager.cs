using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public float initialZPosition = 0.0f;
    public float finalZPosition = 0.0f;
    public float finalPosition;

    public GameObject playerCar;
    public GameObject truckLeftSidePrefab;
    public GameObject truckRightSidePrefab; 

    public GameObject hpHeal;

    public Transform victoryPosition;
    //public GameObject 


    // Start is called before the first frame update
    private void Start()
    {
        finalZPosition = victoryPosition.position.z; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
