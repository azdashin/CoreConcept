using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpinObject : MonoBehaviour
{
    public float rotationSpeed;

    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;

    float xRotation;
    float yRotation;
    float zRotation;

    new GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotateX)
        {
            xRotation = rotationSpeed;
        }
        else
        {
            xRotation = 0;
        }
        if (rotateY)
        {
            yRotation = rotationSpeed;
        }
        else
        {
            yRotation = 0;
        }
        if (rotateZ)
        {
            zRotation = rotationSpeed;
        }
        else
        {
            zRotation = 0;
        }

        transform.Rotate(new Vector3(xRotation, yRotation, zRotation), Space.Self);
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}
