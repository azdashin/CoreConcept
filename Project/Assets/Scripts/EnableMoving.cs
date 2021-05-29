using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMoving : MonoBehaviour
{
    public MovePlatform script;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            script.enabled = true;
        }
    }

}
