using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamble : MonoBehaviour
{
    public MonoBehaviour scriptToEnable;

    void Start()
    {
        // Check if the scriptToEnable is not null
        if (scriptToEnable != null)
        {
            // Generate a random number between 0 and 1
            float randomValue = Random.value;

            // If the random value is less than or equal to 0.5 (50% chance)
            if (randomValue <= 0.5f)
            {
                // Enable the script
                scriptToEnable.enabled = true;
                Debug.Log(scriptToEnable.GetType().Name + " enabled!");
            }
            else
            {
                // Disable the script (optional, as it should be disabled by default)
                scriptToEnable.enabled = false;
                Debug.Log(scriptToEnable.GetType().Name + " disabled.");
            }
        }
        else
        {
            Debug.LogError("Script to enable is not assigned!");
        }
    }
}
