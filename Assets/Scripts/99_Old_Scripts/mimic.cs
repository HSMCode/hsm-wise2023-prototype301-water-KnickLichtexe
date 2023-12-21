using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimic : MonoBehaviour
{
    public Transform targetObject; // The object whose rotation we want to mimic
    public GameObject scriptToDisable; // The script you want to disable
    public float rotationSpeed = 1.0f; // Adjust the rotation speed as needed

    private bool hasCollided = false;

    private void Update()
    {
        if (hasCollided && targetObject != null)
        {
            // Mimic rotation
            transform.rotation = targetObject.rotation;

            // Stand next to the collided object
            Vector3 newPosition = targetObject.position + targetObject.right * 2.0f; // Adjust the position offset
            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "NPC"
        if (other.CompareTag("NPC"))
        {
            hasCollided = true;
            DisableScript();
        }
    }

    private void DisableScript()
    {
        // Disable the script on the specified GameObject
        if (scriptToDisable != null)
        {
            MonoBehaviour scriptComponent = scriptToDisable.GetComponent<MonoBehaviour>();
            if (scriptComponent != null)
            {
                scriptComponent.enabled = false;
            }
            else
            {
                Debug.LogError("Script component not found on the specified GameObject.");
            }
        }
        else
        {
            Debug.LogError("ScriptToDisable GameObject not assigned.");
        }
    }
}
