using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public Vector3 walkVelocity;

    public Vector3 prevWalkVelocity;

    public int numberOfBullets;

    //Control Booleans
    public bool canSwing = true;
    public bool canDash = true;
    public bool canMove = true;
    public bool canShoot = true;
    public bool isHit = false;
    public bool hasSpeeded = false;
    public bool hasUltraInstinted = false;
    public bool hasChangedSword = false;
    public bool isShielded = false;
    //Player Stats
    public float DashCD;
    public float ShootCD;
    public float walkSpeed;
    public float rotateSpeed;
    public int PlayerID;
    public int dashCount;
    public float shieldTime;


    //GOs
    public SwordScript sword;
    public OrbitalScript orbital;

    public float carForce = 100;

    enum playerState
    {
        normal = 0,
        car = 1,

    }

    private int currentState;

    private void Awake()
    {
        //Stat inicialization
        DashCD = 0.7f;
        ShootCD = 50f;
        walkSpeed = 6f;
        rotateSpeed = 8f;
        numberOfBullets = 3;
        dashCount = 1;
        //GO inicialization
        rb = GetComponent<Rigidbody>();

        if (orbital == null)
            orbital = GetComponentInChildren<OrbitalScript>();

        if (sword == null)
            sword = GetComponentInChildren<SwordScript>();

        sword.player = this;

        currentState = 0;
    }
    private void Start()
    {
        
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
                {
                    //carMovement(movementInput);
                    break;

                }

        }
    }

    private void normalMovement(Vector2 movementInput)
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {

                float vval = 0f;
                if (movementInput.y > 0f)
                    vval = 1f;
                else if (movementInput.y < 0f)
                    vval = -1f;

                float hval = 0;
                if (movementInput.x > 0f)
                    hval = 1f;
                else if (movementInput.x < 0f)
                    hval = -1f;

                walkVelocity = new Vector3(walkSpeed * hval, 0, walkSpeed * vval);

            }
            else
            {
                walkVelocity = Vector3.zero;
            }
        }

    }
/*
    private void carMovement(Vector2 movementInput)
    {
        Vector3 carMovement = new Vector3(movementInput.x, 0, movementInput.y);

        rb.AddForce(transform.forward * carForce);

        Debug.Log("HI");


    }*/

    private void OnShoot()
    {
        if (canShoot)
        {
            
            orbital.Shoot();
        }

    }


    public void Hit(float force, Vector3 dir, float time)
    {

        if(!isShielded){
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

    private void OnTriggerEnter(Collider col) {

        
        if(col.gameObject.tag.Equals("BFG") ){

            orbital.BulletsUpgrade(true);
            col.gameObject.SetActive(false);

        } else if(col.gameObject.tag.Equals("Rambo")){

            orbital.BulletsUpgrade(false);
            col.gameObject.SetActive(false);

        }
        else if(col.gameObject.tag.Equals("Sonic")){
            if(!hasSpeeded) col.gameObject.SetActive(false);
            SpeedBoost();
            

        } else if(col.gameObject.tag.Equals("Ultra")){
             if(!hasUltraInstinted) col.gameObject.SetActive(false);
            DashIncrease();
           

        } else if(col.gameObject.tag.Equals("Cloud")){
           if(!hasChangedSword) col.gameObject.SetActive(false);
            changeSword();
            

        } else if(col.gameObject.tag.Equals("Shield")){
             col.gameObject.SetActive(false);
            Shield();
           

        } 
    }

    //Abilidades
    public void DashIncrease(){
        if(!hasUltraInstinted) {dashCount++;
        hasUltraInstinted = true;
        }
    }

    public void SpeedBoost(){
        if(!hasSpeeded) {walkSpeed= walkSpeed*2;
        hasSpeeded=true;}
    }

    public void changeSword(){
        if(!hasChangedSword){
            //TO DO IMPLEMENT SWORD
            sword.swordModel.mesh = GameAssets.i.cloudSwordModel;
            sword.swordMaterial.material = GameAssets.i.cloudSwordMaterial;
            sword.swordCollider.size = new Vector3(
                sword.swordCollider.size.x*5,sword.swordCollider.size.y,sword.swordCollider.size.z*2);
            hasChangedSword = true;
        }
    }


    IEnumerator ShieldNumerator(){
        Debug.Log("pipo");
        while (shieldTime > 0){
            isShielded = true;
            yield return new WaitForSeconds(1f);
            shieldTime--;
        } 
        if(isShielded) isShielded = false;
    }

    public void Shield(){
        shieldTime += 5f;
        if(!isShielded) StartCoroutine(ShieldNumerator());
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
        if (canDash)
        {
            canDash = false;
            StartCoroutine(SlowDashing());
            StartCoroutine(DashCDIng());
        }
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
        
        
        
        
        if(hasUltraInstinted) {

        if(dashCount == 1){

        yield return new WaitForSeconds(DashCD);

        if (hasUltraInstinted && dashCount ==1) 
        
        canDash = true;
        
        dashCount++;
        
        }

        else if (dashCount == 2){
            canDash = true;
           dashCount --; 
           
        }

        } 
        
        else {
            yield return new WaitForSeconds(DashCD);
            canDash = true;

        }



    }


    private void rotateToDirection()
    {
        if (walkVelocity != Vector3.zero)
        {
            transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-walkVelocity), rotateSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {

        switch (currentState)
        {
            case (int)playerState.normal:
                if (canMove)
                {
                    rb.velocity = new Vector3(walkVelocity.x, rb.velocity.y, walkVelocity.z);

                    rotateToDirection();

                }
                break;

            case (int)playerState.car:
                
                
                break;
        }



    }
}
