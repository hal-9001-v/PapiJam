using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarPowerUp : MonoBehaviour
{
    Animator myAnimator;

    private void Awake()
    {
        if (myAnimator == null) {
            myAnimator = GetComponent<Animator>();

            if (myAnimator == null) {
                myAnimator = GetComponentInChildren<Animator>();

            }
        }

    }

    public void setDrift() {
        myAnimator.SetBool("IsDrifting", true);
//        myAnimator.SetTrigger("Drift");

    }

    public void setNormal() {
        myAnimator.SetBool("IsDrifting", false);
    }

    public void hide() {
        gameObject.SetActive(false);

    }

    public void show() {
        gameObject.SetActive(true);
    }


}
