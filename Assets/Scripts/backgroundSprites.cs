using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script moves the sprites in the background of the scene
public class backgroundSprites : MonoBehaviour
{
    void Update()
    {
        Camera mainCamera = Camera.main;
        float distance = mainCamera.transform.position.x - transform.position.x;

        if ( distance > 200)
        {
            transform.position += new Vector3(400, 0, 0);
        }
    }
}