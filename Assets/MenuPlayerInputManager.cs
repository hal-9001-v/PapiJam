using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerInputManager : MonoBehaviour
{
    public int playerNum;
    public charSelectScp[] pArray;
    public charSelectScp playerJoined;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        playerNum = 0;
        pArray = new charSelectScp[4];

    }


    public void playerAdd()
    {
        if (playerNum < 4)
        {

            //Jugador que se une es el jugador que encuentra nuevo
            playerJoined = FindObjectOfType<charSelectScp>();
            //Se añade nuevo jugador al array
            pArray[playerNum] = playerJoined;
            //Se aumenta el índice 
            if (playerNum == 7) { }
            else playerNum++;

        }

    }



    public void playerRemove()
    {
        pArray[playerNum] = null;
        playerNum--;

    }



    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
