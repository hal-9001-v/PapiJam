using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalScript : MonoBehaviour
{
    const int TOP = 50;
    public int timer = TOP;
    public float pos;
    bool restart;

    PlayerController player;
    public float bulletSpeed = 5f;

    public Vector3 lasWalkVelocity;

    private Vector2 arrowInput;

    Vector3 shootDirection;

    float timeToRotate = 0.2f;
    float rotationTimer = 0;

    BulletScript[] myBullets;

    public GameObject bulletPrefab;

    //Control bools
    bool BFGmode;
    bool BFGReady;
    bool gunReady;
    int j ;
    int k ;
    int ammo;
    BulletScript[] bfgArray ;
    // Start is called before the first frame update
    private void Awake()
    {   
         bfgArray = new BulletScript[3];
        
        //Initialize control bools;
        BFGReady = true;
        player = GetComponentInParent<PlayerController>();

        myBullets = new BulletScript[player.numberOfBullets];

        GameObject go;

        for (int i = 0; i < myBullets.Length; i++)
        {
            go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            myBullets[i] = go.GetComponent<BulletScript>();
            myBullets[i].setPlayer(player);
        }

        k = 0;
        j = 0;


    }

    
    public void BulletsUpgrade(bool BFG){
        GameObject go;
        
        for (int i = 0; i < myBullets.Length; i++)
            {
                Destroy(myBullets[i].gameObject);
            }
        
        if(BFG){

            BFGmode = true;
            //Escopeta: 9 balas, ráfagas de 3 en 3 Más CD
            if(myBullets.Length != 9){
                myBullets = new BulletScript[9];
            } 
        }
        else {
            BFGmode =false;
            //Metralleta: 5 balas en fila, menos CD
            if(myBullets.Length != 5){
                
                myBullets = new BulletScript[5];
            }
        }

        for (int i = 0; i < myBullets.Length; i++)
            {
                go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                myBullets[i] = go.GetComponent<BulletScript>();
                myBullets[i].setPlayer(player);                
            }

    }

    void Start()
    {
        pos = transform.localPosition.y;
        restart = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotationTimer += Time.deltaTime;

        if (shootDirection != Vector3.zero)
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, Quaternion.LookRotation(Vector3.Normalize(shootDirection)), rotationTimer / timeToRotate);

        OrbitalAnimation();

    }

    public void Shoot()
    {


        if(!BFGmode){

        foreach (BulletScript b in myBullets) {
            if (b.readyToShoot && b.gunReady) {
                b.shoot(transform.position, transform.parent.forward*1000);
                StartCoroutine(GCD(b));
                break;
                } 
                
            }
        } else {
            Vector3 b1;
            Vector3 b2;
            switch(j){
                case 0: k = 0;//012
                j++;
                break;
                case 1: k = 3; //345
                j++;
                break;
                case 2: k = 6; //678
                j = 0;
                break;
       
            }

            
             bfgArray[0] = myBullets[k];
             bfgArray[1] = myBullets[k+1];
             bfgArray[2] = myBullets[k+2];

                if(BFGReady && bfgArray[0].readyToShoot && bfgArray[1].readyToShoot && bfgArray[2].readyToShoot){
                
                 BFGReady = false;
                    b1 = transform.parent.forward;
                    b1 = Quaternion.Euler(0,15,0) * b1; 
                    bfgArray[0].shoot(transform.position, b1*1000);
                    
                    bfgArray[1].shoot(transform.position, transform.parent.forward*1000);
                   
                    b2= transform.parent.forward;
                    b2 = Quaternion.Euler(0,-15,0) * b2; 
                    bfgArray[2].shoot(transform.position, b2*1000);

                    
                   
                    StartCoroutine(BFGCD());
                }
             
            
            

        }
    }
  
    IEnumerator GCD(BulletScript b){
        yield return new  WaitForSeconds(1f);
        
        b.gunReady = true;
    }

    IEnumerator BFGCD(){
        yield return new  WaitForSeconds(1.5f);
        
        BFGReady = true;
    }
    
    


    private void OrbitalAnimation()
    {

        if (timer <= TOP && timer >= 0)
        {
            if (restart == false)
            {
                pos -= 0.01f;
                timer--;
                transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
            }
            if (restart == true)
            {
                pos += 0.01f;
                transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
                timer++;
            }
        }
        if (timer <= 0)
        {
            restart = true;
        }
        if (timer >= TOP)
        {
            restart = false;
        }

    }

    private void OnAim(InputValue value)
    {
 
        arrowInput = value.Get<Vector2>();

        if (arrowInput != Vector2.zero)
        {
            shootDirection = new Vector3(arrowInput.x, 0, arrowInput.y);
            rotationTimer = 0;

        }

    }

}
