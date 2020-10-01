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
            playerControl = GetComponentInParent<PlayerController>();

        if (!rb)
            rb = GetComponentInChildren<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MovementValue", Vector3.SqrMagnitude(rb.velocity));
        animator.SetBool("IsAtacking", playerControl.isSword);
        animator.SetBool("IsLimiting", playerControl.isLimiting);
        animator.SetBool("IsHit", playerControl.hitAnim);
        animator.SetBool("IsWinning", playerControl.isWinning);
        if(playerControl.isLimiting) animator.SetFloat("MovementValue", 0f);
  
    }

    public void setVictory() {
        animator.SetBool("IsWinning", true);
    }

    private void OnLevelWasLoaded(int level)
    {
        //Victory
        if (level == 2) {
            setVictory();
            playerControl.isWinning = true;
            playerControl.canMove = false;
        }
    }
}
