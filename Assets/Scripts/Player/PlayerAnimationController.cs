using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private const string ISMOVING_ANIMATION = "isMoving";
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetMovingAnimation(bool value){
        animator.SetBool(ISMOVING_ANIMATION, value);
    }
    
}
