using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;
    public float VELOCITY = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        moveDirection= new Vector3(inputVector.x,0, inputVector.y);

        //Debug.Log(moveDirection);
            gameObject.transform.position =  (moveDirection);
    }


    void OnUp(){
        Debug.Log("Upping!");
        inputVector = new Vector2(0,1);

    }

    void OnDown()
    {
        Debug.Log("Downing!");

        inputVector = new Vector2(0,-1);


    }

    void OnRight(){
        Debug.Log("Faching!");

         inputVector = new Vector2(1,0);

    }

    void OnLeft(){
                Debug.Log("Comunisting!");

        inputVector = new Vector2(-1,0);
    }

}
