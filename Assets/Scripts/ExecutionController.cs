using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class ExecutionController : MonoBehaviour
{
    private const int TOTAL_EXECUTIONS = 1;
    
    [Range(0, TOTAL_EXECUTIONS - 1)]
    public int executionType = 0;
    public float speed = 20f;
    public float radious = 3f;

    private PlayerController playerControl;
    private bool wasShielded = false;

    [HideInInspector]
    public bool wallLimitReached = false;

    private void Start()
    {
        playerControl = GetComponent<PlayerController>();
    }

    public void doExecution()
    {
        //Dejamos estático al personaje y establecemos colision con limites solamente.
        playerControl.gameObject.layer = 9;
        playerControl.myShield.gameObject.SetActive(false);
        playerControl.myExecutionCollision.gameObject.SetActive(true);
        playerControl.canDash = false;
        playerControl.canMove = false;
        playerControl.canShoot = false;
        playerControl.canSwing = false;
        if (playerControl.isShielded) wasShielded = true;
        playerControl.isShielded = true;

        //Ejecutamos el Dash de la ejecución.
        StartCoroutine(PerformeExecution());
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2) StopAllCoroutines();
    }

    IEnumerator PerformeExecution()
    {
        switch(executionType)
        {
            //Type of Execution.
            case 0:
                while (!wallLimitReached) {
                    playerControl.rb.velocity = playerControl.transform.rotation * Vector3.forward * speed;
                    foreach (GameObject playerGO in GameObject.FindGameObjectsWithTag("Player"))
                    {
                        if (playerGO != gameObject && Vector3.Distance(playerGO.transform.position, transform.position) <= radious &&
                            playerGO.GetComponent<PlayerController>().canBeExecuted)
                        {
                            playerGO.GetComponent<PlayerController>().getExecuted();
                        }
                    }
                    yield return new WaitForEndOfFrame();
                }
                break;

            default:
                Debug.LogWarning("Execution not programmed yet.");
                break;
        }

        //Devolvemos al estado original.
        playerControl.gameObject.layer = 0;
        playerControl.myExecutionCollision.gameObject.SetActive(false);
        playerControl.isLimiting = false;
        playerControl.canDash = true;
        playerControl.canMove = true;
        playerControl.canShoot = true;
        playerControl.canSwing = true;
        playerControl.myShield.gameObject.SetActive(true);
        if (!wasShielded) playerControl.isShielded = false;
        wasShielded = false;

        wallLimitReached = false;
    }
}
