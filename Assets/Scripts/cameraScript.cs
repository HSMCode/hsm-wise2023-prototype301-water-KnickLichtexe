using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed, 0, 0);
    }
}
