using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomAnimationOffset : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        animator.Play("Swim", -1, Random.Range(0f, 1f));
    }

}
