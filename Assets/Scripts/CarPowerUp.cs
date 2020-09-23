using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputActions))]
public class CarPowerUp : MonoBehaviour
{
    private Rigidbody myRB;

    public float force = 1000;
    
    private void Awake()
    { 

        myRB = GetComponent<Rigidbody>();
    }

    private void OnCarMovement(InputAction.CallbackContext value)
    {
        Vector2 direction = value.ReadValue<Vector2>();

        myRB.AddForce(new Vector3(direction.x*force, 0, direction.y*force));
       
    }




}
