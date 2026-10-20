using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] truckEnemies;
    public GameObject nextTruck;

    public Transform cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        truckEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        nextTruck = truckEnemies[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraPosition.position.z - 30 > nextTruck.transform.position.z)
        {
            Truck truck = nextTruck.GetComponent<Truck>();
            truck.TruckParallax();
            
            foreach (GameObject truckPosition in truckEnemies)
            {
                if(truck.transform.position.z > truckPosition.transform.position.z)
                {
                    nextTruck = truckPosition.gameObject;
                }
            }
        }
    }
}
