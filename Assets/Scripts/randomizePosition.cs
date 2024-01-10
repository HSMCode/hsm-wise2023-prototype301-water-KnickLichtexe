using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizePosition : MonoBehaviour
{
    private Vector3 startPos, cameraPos, newPos;
    public float maxOffsetX, maxOffsetY, maxOffsetZ;
    public Transform myCamera;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = myCamera.position;
        
       if (Random.Range(0, 120) < 1)
        {
            Vector3 random = new Vector3
                (startPos.x + cameraPos.x + Random.Range(-maxOffsetX, maxOffsetX),
                 startPos.y + Random.Range(-maxOffsetY, maxOffsetY),
                 startPos.z + Random.Range(-maxOffsetZ, maxOffsetZ));
            transform.position = random;
        }
    }
  
}
