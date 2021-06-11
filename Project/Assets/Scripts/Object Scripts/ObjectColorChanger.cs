using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColorChanger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeMyColor();
        }
    }

    void ChangeMyColor()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
