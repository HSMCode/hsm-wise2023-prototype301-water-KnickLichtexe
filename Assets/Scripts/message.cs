using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class message : MonoBehaviour
{
    void Start()
    {
        Invoke("DeactivateGameObject", 3f);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
