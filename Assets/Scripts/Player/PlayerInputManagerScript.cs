using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerInputManagerScript : MonoBehaviour
{
    public int playerNum;

    List<PlayerController> myPlayerControllers;
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
        myPlayerControllers = new List<PlayerController>();
    }

    public void playersCanQuit(bool b)
    {
        foreach (PlayerController pc in myPlayerControllers)
        {
            pc.canQuit = b;
        }
    }

    public void quitPlayer(PlayerController pc)
    {
        playerNum--;
        myPlayerControllers.Remove(pc);

        int i = 1;
        foreach (PlayerController player in myPlayerControllers)
        {
            player.PlayerID = i;
            player.name = "Player" + i;
            i++;
        }

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
                playerNum++;

                DontDestroyOnLoad(go);

                playerJoined = go.GetComponent<PlayerController>();
                playerJoined.PlayerID = playerNum;

                myPlayerControllers.Add(playerJoined);

                //Se añade nuevo jugador al array

                playerJoined.PlayerID = playerNum;
                playerJoined.name = "Player" + playerNum;

                PlayerSpawn selectedPlayerSpawn = getFreeSpawn();

                if (selectedPlayerSpawn == null)
                {
                    Debug.LogWarning("No spawn for player");
                }
                else
                {
                    selectedPlayerSpawn.spawnPlayer(playerJoined);
                }



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
