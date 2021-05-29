using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFallWarp : MonoBehaviour
{
    public GameObject warpPoint;
    public float teleportFloorLevel;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= teleportFloorLevel)
        {
            transform.position = warpPoint.transform.position;
        }
    }
}
