using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorPersonaje : MonoBehaviour
{

    public int playerNumber;

    public PlayerController myPlayer;
    public SpriteRenderer mySpriteRenderer;
    public Sprite[] charactersPics;

    // Update is called once per frame
    public  void FixedUpdate()
    {
        if (myPlayer == null)
        {
            foreach (PlayerController pc in FindObjectsOfType<PlayerController>())
            {
               

                if(pc.PlayerID == playerNumber && pc!=null){
                    myPlayer = pc;
                    break;
                } else if(myPlayer!=null) {
                    Debug.Log(myPlayer.charSelected);
                    mySpriteRenderer.sprite = charactersPics[myPlayer.charSelected];
                }
            }

        } 
             else {
            mySpriteRenderer.sprite = charactersPics[myPlayer.charSelected];
        }
        }
      
    }


