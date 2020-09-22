using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   public Rigidbody rb; 
   public int parentId;
   public PlayerController player;
   PlayerController playerHit;
   float bulletlife = 15;
   public float bulletForce;
   public float hitStunTime;
   public Vector3 dir;
    private void Awake() {
        bulletForce = 50;
        hitStunTime = 0.25f;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(BulletKill());
    }

    IEnumerator BulletKill(){

        yield return new WaitForSeconds(bulletlife);
    
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        dir = rb.velocity;
    }

    private void OnTriggerEnter(Collider col) {
      if( (col.gameObject.tag.Equals("Player") && parentId != col.GetInstanceID()) || col.gameObject.tag.Equals("Wall")){
            if(col.gameObject.tag.Equals("Player")) {
                playerHit = col.gameObject.GetComponent<PlayerController>();
                playerHit.Hit(bulletForce,1,dir,hitStunTime);}
            Destroy(this.gameObject);
         }  
    }
         
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
