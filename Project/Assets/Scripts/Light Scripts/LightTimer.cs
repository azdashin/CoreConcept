using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour
{
    bool lightOn = true;
    public float timerLightOnLength = 2f;
    public float timerLightOffLength = 3f;
    float timeLeftOn;
    float timeLeftOff;

    new Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();

        timeLeftOn = timerLightOnLength;
        timeLeftOff = timerLightOffLength;
    }

    // Update is called once per frame
    void Update()
    {
        if(lightOn)
        {
            timeLeftOn -= Time.deltaTime;
            if(timeLeftOn <= 0)
            {
                timeLeftOff = timerLightOffLength;
                lightOn = false;
                light.enabled = false;
            }
        }
        else
        {
            timeLeftOff -= Time.deltaTime;
            if(timeLeftOff <= 0)
            {
                timeLeftOn = timerLightOnLength;
                lightOn = true;
                light.enabled = true;
            }
        }

    }
}
