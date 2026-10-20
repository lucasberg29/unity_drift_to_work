using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellShatter : MonoBehaviour
{
    //private bool isHit = false;

    public float timeToDie = 20;
    
    private void Update()
    {
        //if (isHit)
        //{
        //    --timeToDie;
        //    //Debug.Log("Time to destroy: " + timeToDie);
        //}

        //if (timeToDie < 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        Debug.Log("Object enabled");
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 5);
        //isHit = true;
    }


}
