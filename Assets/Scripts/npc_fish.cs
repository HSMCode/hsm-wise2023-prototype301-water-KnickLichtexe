using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_fish : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    void Update()
    {
        // Move the object in the positive Z direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
