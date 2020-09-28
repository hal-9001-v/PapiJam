﻿using UnityEngine;

public class CarPowerUp : MonoBehaviour
{
    Animator myAnimator;
    public PlayerController myPlayer;

    public float hitForce;

    private void Awake()
    {
        if (myAnimator == null)
        {
            myAnimator = GetComponent<Animator>();

            if (myAnimator == null)
            {
                myAnimator = GetComponentInChildren<Animator>();

            }
        }

        hide();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != myPlayer.gameObject) {

            if (other.tag == "Player") {
                other.GetComponent<PlayerController>().Hit(hitForce, other.transform.position - transform.position, 1);

                myPlayer.chargeLimit(2);
            }
        
        }
    }

    public void hide()
    {
        gameObject.SetActive(false);

    }

    public void show()
    {
        gameObject.SetActive(true);
    }


}
