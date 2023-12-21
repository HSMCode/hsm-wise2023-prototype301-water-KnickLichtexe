using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();

        // Check if Animator component exists
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject!");
        }
    }

    void Update()
    {
        // Check for user input or any condition to trigger the animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Trigger the animation by setting the specified trigger parameter
            animator.SetTrigger("Swim");
        }
    }
}
