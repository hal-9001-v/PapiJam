using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalScript : MonoBehaviour
{
    const int TOP = 50;
    public int timer = TOP;
    public float pos;
    bool restart;
    BulletScript bullet;
    PlayerController player;
    public float bulletSpeed = 5f;
    // Start is called before the first frame update
    private void Awake() {
        player = GetComponentInParent<PlayerController>();
    }
    void Start()
    {   
        
        pos = transform.localPosition.y;
        restart = false;
    }
    
    

    // Update is called once per frame
    void FixedUpdate()
    {   
       OrbitalAnimation();
    }

    public void Shoot(){

        Debug.Log("FIIIRE A LAZER PRUUUUU");
        
        bullet = Instantiate(GameAssets.i.bullet,new Vector3(transform.position.x , transform.position.y ,transform.position.z), transform.rotation);
        bullet.player = player;
        bullet.parentId = player.id;
        if(player.walkVelocity != Vector3.zero) bullet.rb.AddForce(player.walkVelocity * 100);
        else bullet.rb.AddForce(player.lasWalkVel * 100);
        StartCoroutine(ShootCDing());
    }

     IEnumerator ShootCDing(){  
        
        yield return new WaitForSeconds(player.ShootCD);     
        player.canShoot = true;

    }

    private void OrbitalAnimation(){

        if (timer <= TOP && timer >= 0){
            if(restart == false){
                pos -= 0.01f;
                timer--;
                transform.localPosition = new Vector3(transform.localPosition.x,pos, transform.localPosition.z);  
            }
            if(restart == true){
                pos += 0.01f;
                transform.localPosition = new Vector3(transform.localPosition.x,pos, transform.localPosition.z);
                timer++;
            } 
        } if( timer <= 0) {
            restart = true;
        }
        if(timer >= TOP) {
            restart = false;
        }

    }

}
