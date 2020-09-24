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
    public bool isSword = false; 
    //Player Stats
    public float DashCD;
    public float ShootCD;
    public float walkSpeed;
    public float carSpeed;
    public float rotateSpeed;
    public int PlayerID;
    public int dashCount;
    public float shieldTime;


    //GOs
    public SwordScript sword;
    public OrbitalScript orbital;
    public CarPowerUp myCar;
    public ShieldScript myShield;
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

        if (myCar == null)
            myCar = GetComponentInChildren<CarPowerUp>();
        if (myShield == null)
            myShield= GetComponentInChildren<ShieldScript>();
            myShield.gameObject.SetActive(false);

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
        myCar.gameObject.SetActive(true);
        canSwing = false;
        canDash = false;
        canMove = true;
        canShoot = false;
        isShielded = true;

        carIsDrifting = false;

        currentState = (int)playerState.car;
    }

    public void enterNormalState()
    {
        exitState();
        myCar.gameObject.SetActive(false);
        canSwing = true;
        canDash = true;
        canMove = true;
        canShoot = true;
        isShielded = false;

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
            isSword = true;
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

        if(!isShielded){
        isHit = true;
        canDash = false;
        canMove = false;
        canShoot = false;
        canSwing = false;

    
        StartCoroutine(HitStun(time));
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
        if ((col.gameObject.tag.Equals("Wall") || col.gameObject.tag.Equals("Player")) && isHit == true && !col.gameObject.tag.Equals("Escudin"))
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
        
         if(!isSword){
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
        while (shieldTime > 0){
            isShielded = true;
            yield return new WaitForSeconds(1f);
            shieldTime--;
        } 
        if(isShielded) {isShielded = false;
            myShield.gameObject.SetActive(false);
        };
    }

    public void Shield(){
        myShield.gameObject.SetActive(true);
        shieldTime += 5f;
        if(!isShielded) StartCoroutine(ShieldNumerator());
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
        if (movementDirection != Vector3.zero)
        {
            transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movementDirection), rotateSpeed * Time.deltaTime);
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
