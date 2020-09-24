using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    public int playerID;

    public float bulletForce = 50;
    public float hitStunTime = 0.25f;

    public float bulletTime = 5;

    public Vector3 dir;
    public bool gunReady;
    public bool readyToShoot;

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();

        readyToShoot = true;
        gunReady = true;
        gameObject.SetActive(false);
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
                if (pl.PlayerID != playerID)
            {
                Vector3 dir = rb.velocity;
                
                col.gameObject.GetComponent<PlayerController>().Hit(bulletForce, dir, hitStunTime);
                readyToShoot = true;
                gameObject.SetActive(false);  


            }


            
        } else if (col.gameObject.tag.Equals("Wall") ||col.gameObject.tag.Equals("Escudin")){
            readyToShoot = true;
            gameObject.SetActive(false);  
        }

    }

  

}
