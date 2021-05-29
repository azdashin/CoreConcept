using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFallReset : MonoBehaviour
{
    public float teleportFloorLevel;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= teleportFloorLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
    }
}
