using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{

    private bool decideToFeed = false;

    void Update() {
        // Check for PlayerInput
        if (Input.GetButtonDown("Jump")){
            decideToFeed = true;
        }
        else {
            decideToFeed = false;
        }
    }

    public bool Feed() {
        return decideToFeed;
    }


}


