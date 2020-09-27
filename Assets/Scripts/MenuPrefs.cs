using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPrefs : MonoBehaviour
{
   
    public int p0;
    public int p1;
    public int p2;
    public int p3;

    public MenuManager menu;
    public int[] players;
    public bool inMenu = true;

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        menu = GameObject.Find("Main Camera").GetComponent<MenuManager>();
    }

    private void Start() {
        p0=0;
        p1=1;
        p2=2;
        p3=3;
    }

    private void FixedUpdate() {
        if (inMenu)
        {
            if (GameObject.Find("Selector1"))
            {

                if (playersReady())
                {
                    setPlayers();

                    if (menu.playersNum == 2)
                    {
                        p0 = players[0];
                        p1 = players[1];
                        p2 = 4;
                        p3 = 4;
                    }
                    else if (menu.playersNum == 3)
                    {
                        p0 = players[0];
                        p1 = players[1];
                        p2 = players[2];
                        p3 = 4;
                    }
                    else if (menu.playersNum == 4)
                    {
                        p0 = players[0];
                        p1 = players[1];
                        p2 = players[2];
                        p3 = players[3];
                    }

                    inMenu = false;
                    // SceneManager.LoadScene(Escena de Juego); 
                    Debug.Log("A luchar!");
                }
            }
        }
       
        
    }

    bool playersReady()
    {
        bool ready = true;

        for(int i = 0; i<menu.playersNum; i++)
        {
            if (!GameObject.Find("Selector" + (i + 1)).GetComponent<charSelectScp>().isReady)
            {
                ready = false;
            }
        }

        return ready;
    }

        

    

    void setPlayers()
    {
        players = new int[menu.playersNum];

        for(int i = 0; i<menu.playersNum; i++)
        {
            players[i] = GameObject.Find("Selector" + (i+1)).GetComponent<charSelectScp>().charSelected;
        }
    }

}
