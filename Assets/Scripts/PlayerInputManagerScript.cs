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
        pArray = new PlayerController[8];
        
    }
    
    public void playerAdd(){
        if(playerNum < 8){
        
        playerJoined = FindObjectOfType<PlayerController>();
        pArray[playerNum] = playerJoined; 
        playerNum++;
        
        }
    
    }

    

    public void playerRemove(){
        playerNum--;
    }
    
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
