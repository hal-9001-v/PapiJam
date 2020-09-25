using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerInputManagerScript : MonoBehaviour
{
    public int playerNum;
    public PlayerController[] pArray;
    PlayerInputManager myInputManager;

    private PlayerSpawn[] myPlayerSpawns;

    private void Awake()
    {
        myInputManager = GetComponent<PlayerInputManager>();

        myPlayerSpawns = GameObject.FindObjectsOfType<PlayerSpawn>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Son 8 por que cada jugador tiene dos players, el orbital y el jugador.
        pArray = new PlayerController[4];

    }

    public void setCanJoin(bool canJoin)
    {
        if (canJoin)
            myInputManager.EnableJoining();
        else
            myInputManager.DisableJoining();
    }

    public void playerAdd()
    {
        if (playerNum < 4)
        {
            GameObject go;
            PlayerController playerJoined;

            //Jugador que se une es el jugador que encuentra nuevo
            go = GameObject.Find("Player(Clone)");

            if (go != null)
            {
                playerJoined = go.GetComponent<PlayerController>();

                //Se añade nuevo jugador al array
                pArray[playerNum] = playerJoined;
                pArray[playerNum].PlayerID = playerNum;
                pArray[playerNum].name = "Jugador" + playerNum;

                PlayerSpawn selectedPlayerSpawn = getFreeSpawn();

                if (selectedPlayerSpawn == null)
                {
                    Debug.LogWarning("No spawn for player");
                }
                else
                {
                    selectedPlayerSpawn.spawnPlayer(pArray[playerNum]);
                }

                //Se aumenta el índice 
                if (playerNum != 3)
                    playerNum++;
            }
        }

    }

    PlayerSpawn getFreeSpawn()
    {
        foreach (PlayerSpawn ps in myPlayerSpawns)
        {
            if (ps.myPlayer == null)
            {
                return ps;
            }
        }

        return null;
    }

}
