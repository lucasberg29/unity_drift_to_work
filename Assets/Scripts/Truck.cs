using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    enum TruckRoadSide
    {
        Left,
        Right
    }

    [SerializeField]
    private TruckRoadSide truckRoadSide;

    private const float xOptionsRightSide = 2.43f;
    private const float xOptionsLeftSide = -2.3f;

    private float yOptionBothSides = 0.45f;


    public float minimunStep = 40.0f;

    public bool leftImageEnabled = true;
    public bool rightImageEnabled = true;

    public Collider playerCollider;

    public void TruckParallax()
    {

        float newXValue = Random.value;

        if (newXValue < 0.5)
        {
            if (transform.rotation.y < 0)
            {
                transform.Rotate(0, 180, 0);
            }

            //Debug.Log("Truck moved left");
            transform.position =
            new Vector3(xOptionsLeftSide, yOptionBothSides, transform.position.z + (newXValue * minimunStep) + minimunStep);

            leftImageEnabled = true;
            rightImageEnabled = false;
        }
        else
        {
            if (transform.rotation.y > 0)
            {
                transform.Rotate(0, -180, 0);
            }

            //Debug.Log("Truck moved right");
            transform.position =
            new Vector3(xOptionsRightSide, yOptionBothSides, transform.position.z + (newXValue * minimunStep) + minimunStep);

            leftImageEnabled = false;
            rightImageEnabled = true;
        }
    }

    private void Start()
    {
        //Physics.IgnoreCollision(playerCollider, GetComponent<Collider>());
    }

    void Update()
    {
        if (!leftImageEnabled)
        {
            GameObject leftSign = GameObject.Find("LeftSign");
            //leftSign.SetActive(false);
        }

        if (!rightImageEnabled)
        {
            GameObject rightSign = GameObject.Find("RightSign");
            //rightSign.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {

        }
    }
}
