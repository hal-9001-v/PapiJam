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

    public Vector3 lasWalkVelocity;

    private Vector2 arrowInput;
    Rigidbody rb;

    bool firstTime;

    Vector3 shootDirection;

    float timeToRotate = 0.2f;
    float rotationTImer = 0;

    // Start is called before the first frame update
    private void Awake()
    {
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
            rotationTImer += Time.deltaTime;

            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, Quaternion.LookRotation(Vector3.Normalize(shootDirection)), rotationTImer / timeToRotate);

            OrbitalAnimation();

    }

    public void Shoot()
    {
        bullet = Instantiate(GameAssets.i.bullet, transform.position, Quaternion.identity);
        bullet.player = player;
        bullet.parentId = player.id;
        bullet.rb.AddForce(transform.forward * 1000);
        StartCoroutine(ShootCDing());
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

        if (arrowInput != Vector2.zero) {
            shootDirection = new Vector3(arrowInput.x, 0, arrowInput.y);
            rotationTImer = 0;

        }

        Debug.Log(arrowInput);
    }

}
