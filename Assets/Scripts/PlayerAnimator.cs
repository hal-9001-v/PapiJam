using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public PlayerController playerControl;
    public Rigidbody rb;

    // Start is called before the first frame update
    private void Awake()
    {
        if (!animator)
            animator = GetComponentInChildren<Animator>();

        if (!playerControl)
            playerControl = GetComponentInChildren<PlayerController>();

        if (!rb)
            rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MovementValue", Vector3.SqrMagnitude(rb.velocity));
        animator.SetBool("IsAtacking", playerControl.isSword);
        animator.SetBool("IsLimiting", playerControl.isLimiting);
        if(playerControl.isLimiting) animator.SetFloat("MovementValue", 0f);
        animator.SetBool("IsHit", playerControl.isHit);

    }
}
