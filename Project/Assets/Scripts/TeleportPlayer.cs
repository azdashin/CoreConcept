using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject teleportLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if(controller != null)
            {
                controller.enabled = false;
                controller.transform.position = teleportLocation.transform.position;
                controller.enabled = true;
            }
        }
    }



}
