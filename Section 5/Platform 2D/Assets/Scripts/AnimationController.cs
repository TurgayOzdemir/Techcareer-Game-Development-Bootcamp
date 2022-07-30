using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    InputHandler inputHandler;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputHandler = GetComponent<InputHandler>();
    }

    void Update()
    {
        if (inputHandler.GetAxis() != 0)
        {
            animator.SetBool("isMove",true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
    }

    public void JumpAnimation()
    {
        animator.SetTrigger("jumpTrigger");
    }
}
