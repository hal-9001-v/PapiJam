using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerController player;

    PlayerController playerHit;

    public float swordForce = 150;
    public float hitStunTime = 1;

    public Vector3 dir;

    public float rotation = 15;

    public void attack() {
        gameObject.SetActive(true);

        StartCoroutine(Attack());
    }

    private void Awake()
    {
        gameObject.SetActive(false);

    }

    IEnumerator Attack()
    {


        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        player.rb.velocity = Vector3.zero;
        player.canMove = false;
        player.canSwing = false;
        
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(0, rotation, 0);
        }
        yield return new WaitForSeconds(0.55f);

        rotation = -rotation;

        player.canMove = true;
        player.canSwing = true;

        gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider col) {            
        Debug.Log("PlayerHit");
      if( (col.gameObject.tag.Equals("Player") )){
            if(player.walkVelocity != Vector3.zero) dir = player.walkVelocity;
             else dir = player.lastWalkVel;
            if(col.gameObject != null)
            playerHit = col.gameObject.GetComponent<PlayerController>();
            playerHit.Hit(swordForce,2,dir,hitStunTime);
            }
         
    }
         
        
  
}
