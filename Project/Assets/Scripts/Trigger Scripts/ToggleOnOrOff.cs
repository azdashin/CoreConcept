using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnOrOff : MonoBehaviour
{
    public GameObject objectToToggle;
    public string tag; 

    private float time = 0f;
    public float timer = 2f;

    // If both are selected, the gameObject will be switching between active and inactive constantly.
    public bool ActivateObjectAfterTimer;
    public bool DeactivateObjectAfterTimer;

    // Toggle off or on only
    public bool ToggleOnOnly;
    public bool ToggleOffOnly;

    // Delay time is set to 0 so its basically off until the user changes it.
    public float delayTime = 0;

    void Update()
    {
        if (ActivateObjectAfterTimer == true)
        {
            if (!objectToToggle.active)
            {
                time += Time.deltaTime;
                if (time > timer)
                {
                    time = 0f; //reset time
                    objectToToggle.SetActive(true);
                }
            }
        }
        if (DeactivateObjectAfterTimer == true)
        {
            if (objectToToggle.active)
            {
                time += Time.deltaTime;
                if (time > timer)
                {
                    time = 0f; //reset time
                    objectToToggle.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tag)
        {
            // Start the delay. 
            StartCoroutine(Delay(delayTime));
        }
    }

    // Delay
    private IEnumerator Delay(float delay)
    {
        if (objectToToggle.active == true)
        {
            if (ToggleOnOnly == false)
            {
                // Wait a few seconds based on the user's input
                yield return new WaitForSeconds(delay);
                objectToToggle.SetActive(false);
            }
        }
        else
        {
            if (ToggleOffOnly == false)
            {
                objectToToggle.SetActive(true);
            }
        }
    }


}
