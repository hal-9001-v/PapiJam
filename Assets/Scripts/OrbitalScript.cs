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

    PlayerController player;
    public float bulletSpeed = 5f;

    public Vector3 lasWalkVelocity;

    private Vector2 arrowInput;

    Vector3 shootDirection;

    float timeToRotate = 0.2f;
    float rotationTimer = 0;

    BulletScript[] myBullets;

    public GameObject bulletPrefab;


    // Start is called before the first frame update
    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();

        myBullets = new BulletScript[player.numberOfBullets];

        GameObject go;

        for (int i = 0; i < myBullets.Length; i++)
        {
            go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            myBullets[i] = go.GetComponent<BulletScript>();
            myBullets[i].playerID = player.GetInstanceID();
        }


    }

    void Start()
    {
        pos = transform.localPosition.y;
        restart = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotationTimer += Time.deltaTime;

        if (shootDirection != Vector3.zero)
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, Quaternion.LookRotation(Vector3.Normalize(shootDirection)), rotationTimer / timeToRotate);

        OrbitalAnimation();

    }

    public void Shoot()
    {
        foreach (BulletScript b in myBullets)
        {
            if (b.readyToShoot)
            {
                b.shoot(transform.position, transform.parent.forward * 1000);
                break;
            }
        }
    }

    IEnumerator ShootCDing()
    {

        yield return new WaitForSeconds(player.ShootCD);
        player.canShoot = true;

    }

    private void OrbitalAnimation()
    {

        if (timer <= TOP && timer >= 0)
        {
            if (restart == false)
            {
                pos -= 0.01f;
                timer--;
                transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
            }
            if (restart == true)
            {
                pos += 0.01f;
                transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
                timer++;
            }
        }
        if (timer <= 0)
        {
            restart = true;
        }
        if (timer >= TOP)
        {
            restart = false;
        }

    }

    private void OnAim(InputValue value)
    {
 
        arrowInput = value.Get<Vector2>();

        if (arrowInput != Vector2.zero)
        {
            shootDirection = new Vector3(arrowInput.x, 0, arrowInput.y);
            rotationTimer = 0;

        }

    }

}
