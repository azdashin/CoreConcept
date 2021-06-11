using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallWarp : MonoBehaviour
{
    public GameObject warpPoint;
    public float teleportFloorLevel;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= teleportFloorLevel)
        {
            CharacterController controller = GetComponent<CharacterController>();

            if (controller != null)
            {
                controller.enabled = false;
                controller.transform.position = warpPoint.transform.position;
                controller.enabled = true;
            }
        }
    }
}
