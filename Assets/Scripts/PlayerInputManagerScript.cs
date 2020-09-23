using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputManagerScript : MonoBehaviour
{
    public int playerNum;
    public PlayerController[] pArray;
    public PlayerController playerJoined;
    PlayerInputManager pim;
    private void Awake() {
        pim = GetComponent<PlayerInputManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerNum = 0;
        //Son 8 por que cada jugador tiene dos players, el orbital y el jugador.
        pArray = new PlayerController[8];
        
    }
    

    public void playerAdd(){
        if(playerNum < 8){
        
        //Jugador que se une es el jugador que encuentra nuevo
        playerJoined = FindObjectOfType<PlayerController>();
        //Se añade nuevo jugador al array
        pArray[playerNum] = playerJoined;
        //Se aumenta el índice 
        if(playerNum == 7){} 
        else playerNum++;
        
        }
    
    }

    

    public void playerRemove(){
        pArray[playerNum] = null;
        playerNum--;
        
    }
    
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
