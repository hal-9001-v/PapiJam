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
    BulletScript bullet;
    PlayerController player;
    public float bulletSpeed = 5f;

    public Vector3 walkVelocity;
    public Vector3 lastWalkVelocity;

    private Vector2 arrowInput;
    Rigidbody rb;

    bool firstTime;
    // Start is called before the first frame update
    private void Awake() {
        firstTime = true;
        player = GetComponentInParent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        
    }
    
    void Start()
    {   
        pos = transform.localPosition.y;
        restart = false;
    }
    
    

    // Update is called once per frame
    void FixedUpdate()
    {       
       gameObject.transform.position = transform.position = player.transform.position + (transform.position - player.transform.position).normalized * 0.2f;;
       OrbitalAnimation();
    }

    public void Shoot(){

        Debug.Log("FIIIRE A LAZER PRUUUUU");
        
        bullet = Instantiate(GameAssets.i.bullet,new Vector3(transform.position.x , transform.position.y ,transform.position.z), transform.rotation);
        bullet.player = player;
        bullet.parentId = player.id;
        bullet.rb.AddForce(lastWalkVelocity*100);
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

        private void OnAim(InputValue value)
    {
        arrowInput = value.Get<Vector2>();
        ProcessInput();
        
    }

      float OrbitSpeed = 500.0f;

    void ProcessInput(){
      

       if(walkVelocity != Vector3.zero) lastWalkVelocity = walkVelocity;
        gameObject.transform.parent.LookAt(transform.position  - lastWalkVelocity);
        walkVelocity = Vector3.zero;

        float vval = 0f;
        if (arrowInput.y > 0f) { vval += 1f; }
        else if (arrowInput.y < 0f) { vval -= 1f; }

        float hval = 0f;
        if (arrowInput.x > 0f) { hval += 1f; }
        else if (arrowInput.x < 0f) { hval -= 1f; }

        if (vval != 0) { walkVelocity += Vector3.forward * vval * 6f;
}
        if (hval != 0) { walkVelocity += Vector3.right * hval * 6f; 
}
            }


    private void LateUpdate()
    { 
        if (arrowInput == Vector2.zero ) { 
            walkVelocity = Vector3.zero;
            
            } 

    }


}
