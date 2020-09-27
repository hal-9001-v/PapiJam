using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;

    //ANGEL USA setPlayer
    PlayerController myPlayer;

    public float limitCharge = 1;

    public float bulletForce;
    public float hitStunTime = 0.25f;

    public float bulletTime = 5;

    public Vector3 dir;
    public bool gunReady;
    public bool readyToShoot;
    GameObject hitParticle;
    private void Awake()
    {   
        bulletForce = 200;

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

            if (pl.PlayerID != myPlayer.PlayerID)
            {
                Vector3 dir = rb.velocity;
                hitParticle = Instantiate(GameAssets.i.particles[2], col.gameObject.transform);
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



    public void setPlayer(PlayerController player)
    {
        myPlayer = player;
    }


}
