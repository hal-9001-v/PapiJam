using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
   public Rigidbody rb; 
   public PlayerController player;
   PlayerController playerHit;
   public float swordForce;
   public float hitStunTime;
   public Vector3 dir;
    private void Awake() {
        swordForce = 150;
        hitStunTime = 1;
        StartCoroutine(SwordKill());
    }

    IEnumerator SwordKill(){

        yield return new WaitForSeconds(0.55f);
        Debug.Log("Sword is getting Destroyed");
        Destroy(gameObject);
    }

   
    private void OnTriggerEnter(Collider col) {            
        Debug.Log("PlayerHit");
      if( (col.gameObject.tag.Equals("Player") && player.id != col.GetInstanceID())){
            if(player.walkVelocity != Vector3.zero) dir = player.walkVelocity;
             else dir = player.lasWalkVel;
            if(col.gameObject != null)
            playerHit = col.gameObject.GetComponent<PlayerController>();
            playerHit.Hit(swordForce,2,dir,hitStunTime);
            }
         
    }
         
        
  
}
