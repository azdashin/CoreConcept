using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDetector : MonoBehaviour
{
    MeshRenderer ballRenderer;
    new Light light;

    private void Start()
    {
        ballRenderer = GetComponent<MeshRenderer>();
        light = GetComponentInChildren<Light>();

        ballRenderer.enabled = false;
        light.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ballRenderer.enabled = true;
            light.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ballRenderer.enabled = false;
            light.enabled = false;
        }
    }

}
