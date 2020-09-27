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
    public Vector3 dir;
    GameObject hitParticle;

    public float rotation = 15;

    public void attack()
    {
        gameObject.SetActive(true);
        if(swordCollider==null) swordCollider = GetComponent<BoxCollider>();
        StartCoroutine(Attack());
    }

    private void Awake()
    {swordForce = 250;
        gameObject.SetActive(false);

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

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(0, rotation, 0);
        }
        yield return new WaitForSeconds(0.55f);

        rotation = -rotation;
        cloudSword.transform.Rotate(0,0,180);
        normalSword.transform.Rotate(0,0,180);
        myPlayer.canMove = true;
        myPlayer.canSwing = true;
        myPlayer.isSword = false;

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

            if (hitPlayer != null)
            {
                dir = Vector3.Normalize(hitPlayer.transform.position - transform.position);
                hitPlayer.Hit(swordForce, dir, hitStunTime);

                if (myPlayer != null)
                {
                    if(cloudSword.gameObject.activeSelf) SoundManager.PlaySound(SoundManager.Sound.GolpePuerro, 0.1f);
                    if(normalSword.gameObject.activeSelf) SoundManager.PlaySound(SoundManager.Sound.GolpePuerro, 0.1f);
                    hitParticle = Instantiate(GameAssets.i.particles[3], col.gameObject.transform);
                    hitParticle.transform.parent = null;
                    StartCoroutine(DestroyParticles());
                    myPlayer.chargeLimit(limitCharge);
                }

            }

        }

    }


    IEnumerator DestroyParticles(){
        yield return new WaitForSeconds(1);
        Destroy(hitParticle);
    }
    private void LateUpdate() {
    }

}
