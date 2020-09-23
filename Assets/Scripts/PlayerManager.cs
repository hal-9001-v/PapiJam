using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //el pis contiene a los jugadores
    public PlayerInputManagerScript pis;

    MenuPrefs mp ;
    //Un meshrenderer y un meshfilter por cada jugador.
    public MeshRenderer meshP1;
    public MeshRenderer meshP2;
    public MeshRenderer meshP3;
    public MeshRenderer meshP4;
    public MeshFilter meshFP1;
    public MeshFilter meshFP2;
    public MeshFilter meshFP3;
    public MeshFilter meshFP4;
    //un meshrenderer y un meshfilter por cada orbital
    public MeshRenderer meshO1;
    public MeshRenderer meshO2;
    public MeshRenderer meshO3;
    public MeshRenderer meshO4;
    public MeshFilter meshFO1;
    public MeshFilter meshFO2;
    public MeshFilter meshFO3;
    public MeshFilter meshFO4;
    // Start is called before the first frame update
    private void Awake() {
        //buscamos el pis
        pis = FindObjectOfType<PlayerInputManagerScript>();
        mp = FindObjectOfType<MenuPrefs>();
    }
    void Start()
    {
      
        
    }

    public void PlayerManagement(){
            
        StartCoroutine(ManagePlayerWait());
     
    }

    IEnumerator ManagePlayerWait(){

        //Esperamos para que se inicialicen los hijos del player 
        yield return new WaitForSeconds(0.1f);
        if(pis.pArray != null){
            if(pis.pArray[0] != null ){
                //se busca el meshrenderer de este cacharro
                meshP1 = pis.pArray[0].GetComponentInChildren<MeshRenderer>(); 
                //Se usa GA para meterle el material que toca
                meshP1.material = GameAssets.i.mArray[mp.p1];
                //Se busca el meshfilter de este cacharro
                meshFP1 = pis.pArray[0].GetComponentInChildren<MeshFilter>();
                //lo mismo para el modelo
                meshFP1.mesh = GameAssets.i.meshArray[mp.p1];
                if(pis.pArray[0].orbital != null ){
                        //Lo mismo para los orbitales
                        meshO1 = pis.pArray[0].orbital.GetComponentInChildren<MeshRenderer>(); 
                        meshO1.material = GameAssets.i.mOArray[mp.p1];
                        meshFO1 = pis.pArray[0].orbital.GetComponentInChildren<MeshFilter>();
                        meshFO1.mesh = GameAssets.i.meshOArray[mp.p1];
                    }
                    //Se comprueba para todos que el jugador (2,4,6 por que son dos players por jugador) sea nulo antes de sobreescribir.
                    //Se hace lo mismo que para el anterior para todos
                    if(pis.pArray[2] != null && pis.pArray[2].orbital != null) {
                        meshP2 = pis.pArray[2].GetComponentInChildren<MeshRenderer>(); 
                        meshP2.material = GameAssets.i.mArray[mp.p2];
                        meshFP2 = pis.pArray[2].GetComponentInChildren<MeshFilter>(); 
                        meshFP2.mesh = GameAssets.i.meshArray[mp.p2];
            
                        //Orbital
                        meshO2 = pis.pArray[2].orbital.GetComponentInChildren<MeshRenderer>(); 
                        meshO2.material = GameAssets.i.mOArray[mp.p2];
                        meshFO2 = pis.pArray[2].orbital.GetComponentInChildren<MeshFilter>(); 
                        meshFO2.mesh = GameAssets.i.meshOArray[mp.p2];
            
                        if(pis.pArray[4] != null && pis.pArray[4].orbital != null) {
                             meshP3 = pis.pArray[4].GetComponentInChildren<MeshRenderer>(); 
                            meshP3.material = GameAssets.i.mArray[mp.p3];
                            meshFP3 = pis.pArray[4].GetComponentInChildren<MeshFilter>(); 
                            meshFP3.mesh = GameAssets.i.meshArray[mp.p3];

                            //Orbital
                            meshO3 = pis.pArray[4].orbital.GetComponentInChildren<MeshRenderer>(); 
                            meshO3.material = GameAssets.i.mOArray[mp.p3];
                            meshFO3 = pis.pArray[4].orbital.GetComponentInChildren<MeshFilter>(); 
                            meshFO3.mesh = GameAssets.i.meshOArray[mp.p3];
                
                            if(pis.pArray[6] != null && pis.pArray[6].orbital != null){
                                meshP4 = pis.pArray[6].GetComponentInChildren<MeshRenderer>(); 
                                meshP4.material = GameAssets.i.mArray[mp.p4];
                                meshFP4 = pis.pArray[6].GetComponentInChildren<MeshFilter>(); 
                                meshFP4.mesh = GameAssets.i.meshArray[mp.p4];

                                //Orbital
                                meshO4 = pis.pArray[6].orbital.GetComponentInChildren<MeshRenderer>(); 
                                meshO4.material = GameAssets.i.mOArray[mp.p4];
                                meshFO4 = pis.pArray[6].orbital.GetComponentInChildren<MeshFilter>(); 
                                meshFO4.mesh = GameAssets.i.meshOArray[mp.p4];
                            }
                        }
                 }
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
