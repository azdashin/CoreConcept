using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public GameObject object1;

    public float delayTime = 0;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Delay(delayTime));
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
