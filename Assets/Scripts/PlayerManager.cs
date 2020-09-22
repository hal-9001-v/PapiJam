using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerInputManagerScript pis;
    public MeshRenderer[] meshRenderers;
    public MeshRenderer meshP1;
    public MeshRenderer meshP2;
    public MeshRenderer meshP3;
    public MeshRenderer meshP4;
    // Start is called before the first frame update
    private void Awake() {
        pis = FindObjectOfType<PlayerInputManagerScript>();
    }
    void Start()
    {
      
        
    }

    public void PlayerManagement(){
        
        meshP1 = pis.pArray[0].GetComponentInChildren<MeshRenderer>(); 
        meshP1.material = GameAssets.i.mArray[0];
        
        if(pis.pArray[2] != null) {
            meshP2 = pis.pArray[2].GetComponentInChildren<MeshRenderer>(); 
            meshP2.material = GameAssets.i.mArray[1];
            }
        if(pis.pArray[4] != null) {
            meshP3 = pis.pArray[4].GetComponentInChildren<MeshRenderer>(); 
            meshP3.material = GameAssets.i.mArray[2];
        }
        if(pis.pArray[6] != null){
            meshP4 = pis.pArray[6].GetComponentInChildren<MeshRenderer>(); 
            meshP4.material = GameAssets.i.mArray[3];
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
