﻿using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;

    //ANGEL USA setPlayer
    PlayerController myPlayer;

    public float limitCharge = 1;

    public float bulletForce;
    public float hitStunTime = 0.5f;

    public float bulletTime = 5;

    public Vector3 dir;
    public bool gunReady;
    public bool readyToShoot;
    GameObject hitParticle;

    public OrbitalScript myOrbital;
    public GameObject normalBullet;
    public GameObject bfgBullet;
    private void Awake()
    {   
        
       

        bulletForce = 200;
        
        rb = GetComponent<Rigidbody>();

        readyToShoot = true;
        gunReady = true;
        gameObject.SetActive(false);
    }

    private void Start() {
         if(myOrbital.BFGmode == true ) {
            bfgBullet.SetActive(true);
            normalBullet.SetActive(false);
        }  else {
            bfgBullet.SetActive(false);
            normalBullet.SetActive(true);
        }
        
    }

    IEnumerator BulletTime()
    {
        yield return new WaitForSeconds(bulletTime);
        gameObject.SetActive(false);
        gunReady = true;
        readyToShoot = true;
    }

    public void shoot(Vector3 pos, Vector3 dir)
    {
        if(myOrbital.BFGmode) SoundManager.PlaySound(SoundManager.Sound.Escopeta, 0.1f);
        if(myOrbital.gatlingMode) SoundManager.PlaySound(SoundManager.Sound.Metralleta, 0.1f);
        if(!myOrbital.BFGmode && !myOrbital.gatlingMode) SoundManager.PlaySound(SoundManager.Sound.Disparos, 0.3f);
        gameObject.SetActive(true);
        gunReady = false;
        readyToShoot = false;

        gameObject.transform.position = pos;
        rb.velocity = Vector3.zero;
        rb.AddForce(dir);

        StartCoroutine(BulletTime());
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            GameObject go;
            PlayerController pl;

            go = col.gameObject;
            pl = go.GetComponent<PlayerController>();

            if (pl.PlayerID != myPlayer.PlayerID)
            {
                Vector3 dir = rb.velocity;
                hitParticle = Instantiate(GameAssets.i.particles[2], col.gameObject.transform);
                hitParticle.transform.parent = null;
                StartCoroutine(DestroyParticles());
                col.gameObject.GetComponent<PlayerController>().Hit(bulletForce, dir, hitStunTime);
                readyToShoot = true;
                gameObject.SetActive(false);

                myPlayer.chargeLimit(limitCharge);

            }





        }
        else if (col.gameObject.tag.Equals("Wall"))
        {
            readyToShoot = true;
            gameObject.SetActive(false);
        }

    }



    IEnumerator DestroyParticles(){
        yield return new WaitForSeconds(3);
        Destroy(hitParticle);
    }

    public void setPlayer(PlayerController player)
    {
        myPlayer = player;
    }


}
