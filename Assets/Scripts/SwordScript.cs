
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerController myPlayer;

    public float swordForce = 250;
    public float hitStunTime = 2;
    public float limitCharge = 1;

    public GameObject cloudSword;
    public GameObject normalSword;
    public BoxCollider swordCollider;

    private float startTime = 0;
    public Vector3 dir;
    GameObject hitParticle;

    public Transform constrainPosition;
    public Vector3 posOffset;
    public Vector3 rotOffset;
    public bool firstTime = false;
    public void attack()
    {
        gameObject.SetActive(true);
        if(swordCollider==null) swordCollider = GetComponent<BoxCollider>();
        StartCoroutine(Attack());
    }

    private void Awake()
    {
        hitStunTime = 0.6f;
        swordForce = 600;
        

    }

    
    IEnumerator Attack() { 
        transform.position = new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y, myPlayer.transform.position.z);

        if(myPlayer	.hasChangedSword) {
            cloudSword.SetActive(true);
            normalSword.SetActive(false);
        } else {
            cloudSword.SetActive(false);
            normalSword.SetActive(true);
        }
        myPlayer.rb.velocity = Vector3.zero;
        myPlayer.movementDirection = Vector3.zero;
        myPlayer.canMove = false;
        myPlayer.canSwing = false;
        myPlayer.canDoLimit = false;
        startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < 1.04f)
        {
            cloudSword.transform.position = constrainPosition.position + posOffset;
            normalSword.transform.position = constrainPosition.position + posOffset;
            cloudSword.transform.rotation = Quaternion.Euler(constrainPosition.rotation.eulerAngles + rotOffset);
            normalSword.transform.rotation = Quaternion.Euler(constrainPosition.rotation.eulerAngles + rotOffset);
            yield return new WaitForEndOfFrame();
        }
        myPlayer.canMove = true;
        myPlayer.canSwing = true;
        myPlayer.isSword = false;
        myPlayer.canDoLimit = true;

        gameObject.SetActive(false);

    }

    public void setPlayer(PlayerController player)
    {
        myPlayer = player;
    }

    private void OnTriggerEnter(Collider col)
    {
            
        if ((col.gameObject.tag.Equals("Player")))
        {
            PlayerController hitPlayer = col.GetComponent<PlayerController>();
            
            if (hitPlayer != null && myPlayer!=null)
            {
                
                if(hitPlayer.PlayerID != myPlayer.PlayerID){
                Debug.Log(hitPlayer.name + " hit with sword!");
                
               if(!hitPlayer.isHit){ 

                dir = Vector3.Normalize(hitPlayer.transform.position - transform.position);
                hitPlayer.Hit(swordForce, dir, hitStunTime,0.9f);

                if(cloudSword.gameObject.activeSelf) SoundManager.PlaySound(SoundManager.Sound.EspadaHit, 0.5f);
                if(normalSword.gameObject.activeSelf) SoundManager.PlaySound(SoundManager.Sound.GolpePuerro, 0.3f);
                    
                hitParticle = Instantiate(GameAssets.i.particles[3], col.gameObject.transform);
                hitParticle.transform.parent = null;
      
                StartCoroutine(DestroyParticles());
                myPlayer.chargeLimit(limitCharge);
               }
               
                    
                      
                }
                

            }

        }

    }

    

    IEnumerator DestroyParticles(){
        yield return new WaitForSeconds(1);
        Destroy(hitParticle);
    }
   

}
