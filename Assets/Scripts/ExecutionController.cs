using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class ExecutionController : MonoBehaviour
{
    private const int TOTAL_EXECUTIONS = 1;
    
    [Range(0, TOTAL_EXECUTIONS - 1)]
    public int executionType = 0;
    public float speed = 5f;
    public float radious = 3f;

    private PlayerController playerControl;

    [HideInInspector]
    public bool 

    private void Start()
    {
        playerControl = GetComponent<PlayerController>();
    }

    public void doExecution()
    {
        //Dejamos estático al personaje.
        playerControl.canDash = false;
        playerControl.canMove = false;
        playerControl.canShoot = false;
        playerControl.canSwing = false;

        //Ejecutamos el Dash de la ejecución.
        StartCoroutine(PerformeExecution());
    }

    IEnumerator PerformeExecution()
    {
        switch(executionType)
        {
            //Type of Execution.
            case 0:
                while () {
                    playerControl.rb.velocity = Vector3.forward * speed;
                    yield return new WaitForEndOfFrame();
                }
                break;

            default:
                Debug.LogWarning("Execution not programmed yet.");
                break;
        }
    }
}
