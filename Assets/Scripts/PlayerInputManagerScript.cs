using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputManagerScript : MonoBehaviour
{
    public int playerNum;
    public PlayerController[] pArray;
    PlayerInputManager pim;
    private void Awake() {
        pim = GetComponent<PlayerInputManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerNum = 0;
        //Son 8 por que cada jugador tiene dos players, el orbital y el jugador.
        pArray = new PlayerController[4];
        
    }
    

    public void playerAdd(){
        if(playerNum < 4){
        GameObject go;
        PlayerController playerJoined;
        //Jugador que se une es el jugador que encuentra nuevo
        go = GameObject.Find("Player(Clone)");
        if (go != null) GameObject.FindWithTag("CameraSwitcher").GetComponent<CameraSwitcher>().addFollowPlayer(go);
        if (go!= null) {playerJoined = go.GetComponent<PlayerController>();
        //Se añade nuevo jugador al array
        pArray[playerNum] = playerJoined;
        pArray[playerNum].PlayerID = playerNum;
        pArray[playerNum].name = "Jugador" + playerNum;
        //Se aumenta el índice 
        if(playerNum == 3){} 
        else playerNum++;
        }
        }
    
    }

    
/*
    public void playerRemove(){
        playerNum--;
        pArray[playerNum] = null;
    }
    */
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
