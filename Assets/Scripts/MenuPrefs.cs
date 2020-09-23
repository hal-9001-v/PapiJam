using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MenuPrefs : MonoBehaviour
{
   
    public int p1;
    public int p2;
    public int p3;
    public int p4;

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
        p1=0;
        p2=1;
        p3=2;
        p4=3;
    }

    private void Start() {
    
    }

    private void FixedUpdate() {
        
        
        
    }

}
