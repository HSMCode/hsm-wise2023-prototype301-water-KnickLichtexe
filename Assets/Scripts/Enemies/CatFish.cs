using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-1 * (Time.deltaTime * 2), 0, 0);
    }
}
