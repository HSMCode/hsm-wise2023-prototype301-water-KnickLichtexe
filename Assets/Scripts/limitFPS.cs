using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitFPS : MonoBehaviour
{
    [SerializeField] private int FPS;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = FPS;
    }
}
