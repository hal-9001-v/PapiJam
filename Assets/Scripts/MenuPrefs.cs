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
        
        p0=0;
        p1=1;
        p2=2;
        p3=3;

      
    }
       

}
