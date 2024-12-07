using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetMouseButtonDown(0);

        // If the player presses the LEFT CLICK key
        if (!isWalking && forwardPressed)
        {
            // Then set the isWalking boolean to true
            animator.SetBool(isWalkingHash, true);
        }

        // If the player is not pressing the W key
        if (isWalking && !forwardPressed)
        {
           // Then set the isWalking boolean to false
           animator.SetBool(isWalkingHash, false);
        }  
    }
}
