using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 movementDirection;

    public int numberOfBullets = 3;

    //Control Booleans
    public bool canSwing = true;
    public bool canDash = true;
    public bool canMove = true;
    public bool canShoot = true;
    public bool canBeHit = true;

    public bool isHit = true;

    //Player Stats
    public float DashCD;
    public float ShootCD;
    public float walkSpeed;
    public float carSpeed;
    public float rotateSpeed;


    //GOs
    public SwordScript sword;
    public OrbitalScript orbital;
    public CarPowerUp myCar;

    float driftDirection = 0;
    private bool carIsDrifting;


    public float extraSpeed;
    private float extraSpeedCounter = 0;


    enum playerState
    {
        normal = 0,
        car = 1,

    }

    public int currentState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (orbital == null)
            orbital = GetComponentInChildren<OrbitalScript>();

        if (sword == null)
            sword = GetComponentInChildren<SwordScript>();

        if (myCar == null)
            myCar = GetComponentInChildren<CarPowerUp>();

        sword.player = this;


    }
    private void Start()
    {
        enterNormalState();
    }

    private void exitState()
    {
        switch (currentState)
        {
            case (int)playerState.normal:

                break;

            case (int)playerState.car:
                driftDirection = 0;
                break;
        }
    }

    public void enterCarState()
    {
        exitState();

        canSwing = false;
        canDash = false;
        canMove = true;
        canShoot = false;
        canBeHit = false;

        carIsDrifting = false;

        currentState = (int)playerState.car;
    }

    public void enterNormalState()
    {
        exitState();

        canSwing = true;
        canDash = true;
        canMove = true;
        canShoot = true;
        canBeHit = true;

        currentState = (int)playerState.normal;
    }

    private void OnGas()
    {

        if (currentState == (int)playerState.car)
        {
            carIsDrifting = !carIsDrifting;

            if (carIsDrifting)
            {
                extraSpeedCounter = 0;
            }
            else {
                extraSpeedCounter = extraSpeed;
            }
        }

    }
    private void OnMovement(InputValue value)
    {
        Vector2 movementInput = value.Get<Vector2>();

        switch (currentState)
        {
            //NORMAL
            case (int)playerState.normal:

                normalMovement(movementInput);

                break;

            //CAR
            case (int)playerState.car:

                carMovement(movementInput);
                break;



        }
    }

    private void OnMelee()
    {

        if ((sword != null || true) && canSwing)
        {
            sword.attack();
        }
    }

    private void OnDash()
    {
        switch (currentState)
        {

            //Normal
            case (int)playerState.normal:
                if (canDash)
                {
                    canDash = false;
                    StartCoroutine(SlowDashing());
                    StartCoroutine(DashCDIng());
                }
                break;

            //Car
            case (int)playerState.car:
                break;


        }

    }

    private void OnShoot()
    {
        if (canShoot)
        {
            orbital.Shoot();
        }

    }

    private void normalMovement(Vector2 movementInput)
    {
        if (canMove)
        {
            movementDirection = new Vector3(movementInput.x, 0, movementInput.y);
        }

    }

    private void carMovement(Vector2 movementInput)
    {
        if (!carIsDrifting)
        {
            if (movementInput.y < 0)
                driftDirection = -movementInput.x;
            else if (movementInput.y > 0)
                driftDirection = movementInput.x;

        }

        movementDirection = new Vector3(movementInput.x, 0, movementInput.y);

    }

    public void Hit(float force, Vector3 dir, float time)
    {
        if (canBeHit)
        {

            isHit = true;
            canDash = false;
            canMove = false;
            canShoot = false;
            canSwing = false;

            rb.AddForce(dir * force);

            StartCoroutine(HitStun(time));
        }

    }

    IEnumerator HitStun(float hitstun)
    {
        yield return new WaitForSeconds(hitstun);
        rb.velocity = Vector3.zero;
        canDash = true;
        canMove = true;
        canSwing = true;
        canShoot = true;
        isHit = false;
    }

    IEnumerator SlowDashing()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0f);
            rb.transform.position += rb.velocity / 5;
            yield return new WaitForSeconds(0.01f);

        }

    }
    IEnumerator DashCDIng()
    {
        yield return new WaitForSeconds(DashCD);
        canDash = true;
    }

    private void rotateToDirection()
    {
        if (movementDirection != Vector3.zero)
        {
            transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movementDirection), rotateSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.tag.Equals("Wall") || col.gameObject.tag.Equals("Player")) && isHit == true)
        {
            rb.velocity = Vector3.zero;
            canDash = true;
            canMove = true;
            canSwing = true;
            canShoot = true;
            isHit = false;
        }
    }


    private void FixedUpdate()
    {

        switch (currentState)
        {
            case (int)playerState.normal:
                if (canMove)
                {
                    rb.velocity = movementDirection * walkSpeed;

                    rotateToDirection();

                }
                break;

            case (int)playerState.car:
                if (canMove)
                {
                    if (extraSpeedCounter > 0)
                    {
                        rb.velocity = movementDirection * (carSpeed + extraSpeedCounter);
                        extraSpeedCounter -= extraSpeed * 0.05f;
                    }
                    else
                    {
                        rb.velocity = movementDirection * carSpeed;
                    }

                    rotateToDirection();

                    //Drift
                    if (carIsDrifting && movementDirection != Vector3.zero)
                    {
                        rb.velocity += transform.right * driftDirection * carSpeed * 1.5f;
                        myCar.setDrift();

                    }
                    else {
                        myCar.setNormal();
                    }
                }


                break;
        }



    }
}
