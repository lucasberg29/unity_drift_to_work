using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneryController : MonoBehaviour
{
    public float parallaxJump = 120.0f;

    public Transform cameraTranform;
    public GameObject [] roads;
    public GameObject currentRoad;

    int initialIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentRoad = roads[initialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTranform.position.z > currentRoad.transform.position.z + 16.0f)
        {
            ParallaxMovement();

            if(initialIndex == (roads.Length - 1))
            {
                initialIndex = 0;
            }
            else
            {
                ++initialIndex;
            }

            currentRoad = roads[initialIndex];
        }
    }

    void ParallaxMovement()
    {
        currentRoad.transform.position = new Vector3(currentRoad.transform.position.x, currentRoad.transform.position.y, currentRoad.transform.position.z + parallaxJump);
    }
}
