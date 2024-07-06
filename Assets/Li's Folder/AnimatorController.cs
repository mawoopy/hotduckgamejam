using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public QuackControl quackControl;
    public ExtendNeck extendNeck;
    public Animator animator;
    bool mouthIsOpen;
    bool isWalking;
    bool isFalling;
    bool mouthHasOpened;

    [SerializeField] private bool showDebugLogs = false;

    // Update is called once per frame
    void Update()
    {
        mouthIsOpen = quackControl.mouseIsOpen;
        if (showDebugLogs) Debug.Log("mouth is open" + mouthIsOpen);
        isWalking = extendNeck.isGrounded;
        if (showDebugLogs) Debug.Log("Is Walking" + isWalking);
        if (!extendNeck.isGrounded && extendNeck.neckHasBack)
        {
            isFalling = true;
            if (showDebugLogs) Debug.Log("Is Falling" + isFalling);
        }
        else
        {
            isFalling = false;
            if (showDebugLogs) Debug.Log("Is Falling" + isFalling);
        }

        if (isWalking)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isFalling", false);
        }
        if (isFalling)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isWalking", false);
        }
        if (mouthIsOpen)
        {
            animator.SetTrigger("mouthIsOpen");
            mouthHasOpened = true;
        }
        if (!mouthIsOpen && mouthHasOpened)
        {
            animator.SetTrigger("mouthIsClose");
            mouthHasOpened = false;
        }

    }
}
