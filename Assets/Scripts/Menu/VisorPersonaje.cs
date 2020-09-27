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
    void Update()
    {
        if (myPlayer == null)
        {
            foreach (PlayerController pc in FindObjectsOfType<PlayerController>())
            {
                if (pc.PlayerID == playerNumber)
                {
                    myPlayer = pc;
                    break;
                }
            }

        }
        else
        {
            mySpriteRenderer.sprite = charactersPics[myPlayer.charSelected];
        }
    }

}
