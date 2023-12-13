using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{

    public float t;
    public GameObject EnemieSwarm;

    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        t = t + Time.deltaTime;

        if (t >= 5)
        {
            Instantiate(EnemieSwarm, new Vector3(30, 2, 1), Quaternion.identity);
            t = 0;
        }
    }
}
