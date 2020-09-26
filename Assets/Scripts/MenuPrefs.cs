using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MenuPrefs : MonoBehaviour
{
   
    public int p0;
    public int p1;
    public int p2;
    public int p3;

    private void Awake() {
        
        DontDestroyOnLoad(gameObject);

    }

    private void Start() {
        p0=0;
        p1=1;
        p2=2;
        p3=3;
    }

    private void FixedUpdate() {
        
        
        
    }

}
