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


    public AudioSource cancion;
    public int numberOfBullets;

    //Control Booleans
    public bool canSwing = false;
    public bool canDash = false;
    public bool canMove = false;
    public bool canShoot = false;
    public bool canshield = true;
    public bool isHit = false;
    public bool hasSpeeded = false;
    public bool hasUltraInstinted = false;
    public bool hasChangedSword = false;
    public bool isShielded = false;
    public bool isSword = false;
    public bool isLimiting = false;
    public bool canDoLimit = false;
    public bool hasPlayedLimitSound = false;
    public bool canBeExecuted = true;

    //Player Stats
    public float DashCD;
    public float ShootCD;
    public float walkSpeed;
    public float carSpeed;
    public float carTime;
    public float rotateSpeed;
    public int PlayerID;
    public int dashCount;
    public float shieldTime;

    //GOs
    public SwordScript sword;
    public OrbitalScript orbital;
    public CarPowerUp myCar;

    public ShieldScript myShield;
    public LimitBar myLimitBar;

    float driftDirection = 0;
    private bool carIsDrifting;

    public float extraSpeed;

    public ExecutionCollisioner myExecutionCollision;
    public PlayerSpawn ps;

    public float limit = 0;
    public float MAXLIMIT = 10;

    public float monsterCharge;

    public int currentState;

    Coroutine stateChanger;

    private const int MAXLIVES = 3;
    public int lives = MAXLIVES;

    public int charSelected;
    public Sprite[] selectorSP;
    public Vector3[] casillasPos;

    public CharacterSelector myCharacterSelector;
    PlayerInputManagerScript myInputManagerScript;
    MenuManager myMenuManager;

    public bool canQuit;

    public CharacterContainer myCharacterContainer;

    GameObject particleDie;



    enum playerState
    {
        normal = 0,
        car = 1,
        menu = 2,

    }

    private void Awake()
    {
        //Stat inicialization
        DashCD = 0.7f;
        ShootCD = 50f;
        carTime = 15.5f;
        rotateSpeed = 8f;
        numberOfBullets = 3;
        dashCount = 1;

        //GO inicialization
        rb = GetComponent<Rigidbody>();

        if (orbital == null)
            orbital = GetComponentInChildren<OrbitalScript>(true);
        if (rb == null)
            rb = GetComponentInChildren<Rigidbody>(true);

        if (sword == null)
            sword = GetComponentInChildren<SwordScript>();

        if (myCar == null)
            myCar = GetComponentInChildren<CarPowerUp>();
        if (myShield == null)
            myShield = GetComponentInChildren<ShieldScript>();

        if (myExecutionCollision == null)
            myExecutionCollision = GetComponentInChildren<ExecutionCollisioner>();

        myShield.gameObject.SetActive(false);
        myExecutionCollision.gameObject.SetActive(false);

        sword.setPlayer(this);

        myLimitBar = LimitBar.getFreeLimitBar();

        myMenuManager = FindObjectOfType<MenuManager>();

        if (myCharacterSelector == null)
        {
            myCharacterSelector = GetComponentInChildren<CharacterSelector>();
            if (myCharacterSelector == null) Debug.LogWarning("No Character Selector On Player");
        }

        myInputManagerScript = FindObjectOfType<PlayerInputManagerScript>();

        if (myInputManagerScript == null)
        {
            Debug.LogWarning("No InputManagerScript on Scene");
        }
        transform.position = new Vector3(10000, 1000, 1000);

        particleDie = Instantiate(GameAssets.i.particles[4], gameObject.transform);
        particleDie.SetActive(false);


    }


    IEnumerator SpawnWait()
    {
        canMove = false;

        yield return new WaitForSeconds(200);

        canMove = true;
        movementDirection = Vector3.zero;
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        enterMenuState();
        hidePlayer();

        canQuit = true;

    }

    private void OnLevelWasLoaded(int level)
    {

        switch (level)
        {
            //Menu
            case 0:

                destroyPlayer();

                break;

            //Mariano
            case 1:

                StartCoroutine(SpawnWait());

                myCharacterContainer.selectSkin(charSelected);

                canQuit = false;

                PlayerSpawn ps = PlayerSpawn.getFreeSpawn();

                if (ps != null)
                {
                    ps.spawnPlayer(this);
                }
                else
                {
                    Debug.LogWarning("No Spawn in scene");
                }


                myLimitBar = LimitBar.getFreeLimitBar();

                if (myLimitBar != null)
                {
                    myLimitBar.assingLimitBar(this);
                    myLimitBar.show();
                }
                else
                {
                    Debug.LogWarning("No free Limit Bar in Scene");
                }

                GameObject cancionFind;
                cancionFind = GameObject.Find("AudioSource");

                if (cancionFind != null)
                {
                    cancion = cancionFind.GetComponent<AudioSource>();
                    cancion.Pause();

                }
                else {
                    Debug.LogWarning("No AudioSource in Scene");
                }



                enterNormalState();
                break;
        }
    }

    public void hidePlayer()
    {
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
        {
            mr.enabled = false;

        }
        foreach (Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = false;
        }

    }

    public void show()
    {
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
        {
            mr.enabled = true;

        }
        foreach (Collider c in GetComponentsInChildren<Collider>())
        {
            c.enabled = true;
        }

    }

    public void chargeLimit(float n)
    {
        limit += n;

        if (limit >= MAXLIMIT && !hasPlayedLimitSound)
        {
            SoundManager.PlaySound(SoundManager.Sound.LimiteAlcanzado, 0.3f);
            myLimitBar.relleno.myImage.color = new Color32(255, 255, 0, 255);
            hasPlayedLimitSound = true;
        }

        if (limit > MAXLIMIT)
        {
            limit = MAXLIMIT;
        }
        else if (limit < 0)
        {
            limit = 0;
        }

        if (myLimitBar != null)
            myLimitBar.setLimit(limit);

    }

    private void exitState()
    {
        switch (currentState)
        {
            case (int)playerState.normal:
                StopAllCoroutines();
                break;

            case (int)playerState.car:
                driftDirection = 0;
                myCar.hide();
                break;
        }
    }

    public void enterCarState()
    {
        exitState();
        myShield.gameObject.SetActive(false);
        myCar.gameObject.SetActive(true);
        canSwing = false;
        canDash = false;
        canMove = true;
        canshield = false;
        canShoot = false;
        isHit = false;
        hasSpeeded = false;
        hasUltraInstinted = false;
        hasChangedSword = false;
        isShielded = true;
        canDoLimit = false;

        carIsDrifting = false;
        SoundManager.PlaySound(SoundManager.Sound.FALDAEUROBEAT, 0.7f);
        cancion.Pause();
        myCar.show();

        currentState = (int)playerState.car;
    }
    public void enterNormalState()
    {
        exitState();
        myCar.gameObject.SetActive(false);
        myCharacterSelector.gameObject.SetActive(false);

        cancion.Play();

        canSwing = true;
        canDash = true;
        canshield = true;
        canMove = true;
        canShoot = true;
        isHit = false;
        hasSpeeded = false;
        hasUltraInstinted = false;
        hasChangedSword = false;
        isShielded = false;
        canDoLimit = true;

        carIsDrifting = false;


        currentState = (int)playerState.normal;

        show();
    }

    public void enterMenuState()
    {

        exitState();
        myCar.gameObject.SetActive(false);
        myCharacterSelector.gameObject.SetActive(true);
        canSwing = false;
        canDash = false;
        canMove = false;
        canShoot = false;
        isHit = false;
        hasSpeeded = false;
        hasUltraInstinted = false;
        hasChangedSword = false;
        isShielded = false;
        canDoLimit = false;

        carIsDrifting = false;


        currentState = (int)playerState.menu;
    }

    public void changeStateTimer(int nextState, float time)
    {

        if (stateChanger != null)
        {
            StopCoroutine(stateChanger);
        }

        stateChanger = StartCoroutine(ChangeStateTimer(nextState, time));
    }

    IEnumerator ChangeStateTimer(int nextState, float time)
    {

        yield return new WaitForSeconds(time);

        switch (nextState)
        {
            case (int)playerState.normal:
                enterNormalState();
                break;

            case (int)playerState.car:
                enterCarState();

                break;

            default:
                Debug.LogWarning("State " + nextState + " does not exist");
                break;
        }

    }
    public void getExecuted()
    {
        --lives;
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            myCar.gameObject.SetActive(false);
            canSwing = true;
            canDash = true;
            canshield = true;
            canMove = true;
            canShoot = true;
            isHit = false;
            hasSpeeded = false;
            hasUltraInstinted = false;
            hasChangedSword = false;
            isShielded = false;
            canDoLimit = true;

            carIsDrifting = false;

            currentState = (int)playerState.normal;

            particleDie.SetActive(true);
            StartCoroutine(DoRegen(4f));
        }

    }

    private IEnumerator DoRegen(float time)
    {
        canBeExecuted = false;

        yield return new WaitForSeconds(time * 0.5f);

        ps.spawnPlayer(this);

        yield return new WaitForSeconds(time * 0.5f);

        canBeExecuted = true;
        particleDie.SetActive(false);
    }
    private void OnLimit()
    {
        if (canDoLimit)
        {
            if (limit >= MAXLIMIT)
            {

                hasPlayedLimitSound = false;
                myLimitBar.relleno.myImage.color = new Color32(95, 122, 254, 255);

                GameObject.FindWithTag("VirtualCamera").GetComponent<VirtualCamShake>().Shake(2f);

                chargeLimit(-MAXLIMIT);

                ExecutionController exController = GetComponent<ExecutionController>();
                if (!exController)
                {
                    Debug.LogWarning("This player isn't able to perform an Execution.");
                }
                else
                {
                    isLimiting = true;
                    exController.doExecution();
                }
            }
        }

    }
    private void OnGas()
    {
        if (currentState == (int)playerState.car)
        {
            carIsDrifting = !carIsDrifting;

        }

    }
    private void OnMovement(InputValue value)
    {

        Vector2 movementInput = value.Get<Vector2>().normalized;

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
            if (movementInput.y > 0)
            {
                if (movementInput.x > 0)
                    driftDirection = -1;
                else
                    driftDirection = 1;

            }
            else if (movementInput.y < 0)
            {
                if (movementInput.x > 0)
                    driftDirection = 1;
                else
                    driftDirection = -1;

            }


            movementDirection = new Vector3(movementInput.x, 0, movementInput.y);

        }
    }

    public void Hit(float force, Vector3 dir, float time)
    {
        if (!isShielded)
        {
            /*switch(characterSelect){
                case 1: 
                    SoundManager.PlaySound(SoundManager.Sound.FurroHit, 0.3f);
                   break;
                case 2:
                SoundManager.PlaySound(SoundManager.Sound.DarsayHit, 0.3f);
                   break;
               case 3: 
               SoundManager.PlaySound(SoundManager.Sound.ViejaHit, 0.3f);
                   break;
               case 4:
               SoundManager.PlaySound(SoundManager.Sound.SansHit, 0.3f);
                   break;

            }*/

            isHit = true;
            canDash = false;
            canMove = false;
            canShoot = false;
            canSwing = false;

            StartCoroutine(HitStun(time));
            rb.AddForce(Vector3.Normalize(dir) * force);
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
        if ((col.gameObject.tag.Equals("Wall") || col.gameObject.tag.Equals("Player")) && !col.gameObject.tag.Equals("Escudin"))
        {
            if (isHit == true)
            {
                rb.velocity = Vector3.zero;
                canDash = true;
                canMove = true;
                canSwing = true;
                canShoot = true;
                isHit = false;
            }
        }
    }

    private void consumeItem(GameObject go)
    {
        Item myItem = go.GetComponent<Item>();

        if (myItem != null)
        {
            myItem.consume();
        }
        else
        {
            Debug.LogWarning("Item" + go.name + " has no Item Component!");
        }

    }

    private void takePowerUp(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "BFG":

                SoundManager.PlaySound(SoundManager.Sound.PowerUp, 0.1f);
                consumeItem(col.gameObject);

                orbital.BulletsUpgrade(true);
                break;

            case "Rambo":
                SoundManager.PlaySound(SoundManager.Sound.PowerUp, 0.1f);
                consumeItem(col.gameObject);

                orbital.BulletsUpgrade(false);

                break;

            case "Sonic":
                SoundManager.PlaySound(SoundManager.Sound.PowerUp, 0.1f);
                consumeItem(col.gameObject);

                if (!hasSpeeded)
                {
                    SpeedBoost();
                }

                break;

            case "Ultra":
                SoundManager.PlaySound(SoundManager.Sound.PowerUp, 0.1f);
                consumeItem(col.gameObject);

                if (!hasUltraInstinted)
                {
                    DashIncrease();
                }

                break;

            case "Cloud":
                SoundManager.PlaySound(SoundManager.Sound.PowerUp, 0.1f);
                consumeItem(col.gameObject);

                if (!hasChangedSword)
                {
                    changeSword();

                }

                break;
            case "Shield":
                SoundManager.PlaySound(SoundManager.Sound.PowerUp, 0.1f);
                consumeItem(col.gameObject);

                Shield();
                break;

            case "Car":
                SoundManager.PlaySound(SoundManager.Sound.PowerUp, 0.1f);
                consumeItem(col.gameObject);

                enterCarState();
                changeStateTimer((int)playerState.normal, carTime);

                break;

            case "Monster":
                SoundManager.PlaySound(SoundManager.Sound.PowerUp, 0.1f);

                consumeItem(col.gameObject);

                chargeLimit(monsterCharge);

                break;

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        takePowerUp(col);
    }

    //Habilidades
    public void DashIncrease()
    {
        if (!hasUltraInstinted)
        {
            dashCount++;
            hasUltraInstinted = true;
        }
    }

    public void SpeedBoost()
    {
        if (!hasSpeeded)
        {
            walkSpeed = walkSpeed * 2;
            hasSpeeded = true;
        }
    }

    public void changeSword()
    {
        if (!hasChangedSword)
        {
            //TO DO IMPLEMENT SWORD
            sword.swordCollider.size = new Vector3(
                sword.swordCollider.size.x, sword.swordCollider.size.y, sword.swordCollider.size.z * 2);
            hasChangedSword = true;
        }
    }

    IEnumerator ShieldNumerator()
    {
        while (shieldTime > 0)
        {
            isShielded = true;
            yield return new WaitForSeconds(1f);
            shieldTime--;
        }
        if (isShielded)
        {
            isShielded = false;
            myShield.gameObject.SetActive(false);
        }
    }

    public void Shield()
    {
        if (canshield)
        {
            myShield.gameObject.SetActive(true);

            shieldTime += 5f;
            if (!isShielded) StartCoroutine(ShieldNumerator());
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
        if (hasUltraInstinted)
        {

            if (dashCount == 1)
            {

                yield return new WaitForSeconds(DashCD);

                if (hasUltraInstinted && dashCount == 1)

                    canDash = true;

                dashCount++;

            }

            else if (dashCount == 2)
            {
                canDash = true;
                dashCount--;

            }

        }

        else
        {
            yield return new WaitForSeconds(DashCD);
            canDash = true;
        }
    }

    private void rotateToDirection()
    {
        if (movementDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotateSpeed * Time.deltaTime);
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


                rb.velocity = movementDirection * carSpeed;
                rotateToDirection();

                //Drift
                if (carIsDrifting && movementDirection != Vector3.zero)
                {
                    rb.velocity = rb.velocity + transform.right * driftDirection * carSpeed * 2f;
                }

                break;
        }


    }


    private void OnUp()
    {
        if (myMenuManager != null)
        {
            myMenuManager.OnUp(myCharacterSelector);
        }

    }

    private void OnDown()
    {
        if (myMenuManager != null)
        {
            myMenuManager.OnDown(myCharacterSelector);
        }


    }

    private void OnLeft()
    {
        if (myMenuManager != null)
        {
            myMenuManager.OnLeft(myCharacterSelector);
        }



    }

    private void OnRight()
    {

        if (myMenuManager != null)
        {
            myMenuManager.OnRight(myCharacterSelector);
        }

    }

    private void OnSelect()
    {
        if (myMenuManager != null)
        {
            myMenuManager.OnSelect(myCharacterSelector);
        }


    }

    private void OnBack()
    {
        if (myMenuManager != null)
        {
            myMenuManager.OnBack();
        }
    }

    void destroyPlayer()
    {
        foreach (BulletScript bullet in orbital.myBullets)
        {
            Destroy(bullet.gameObject);
        }

        foreach (BulletScript bullet in orbital.bfgArray)
        {
            if (bullet != null)
                Destroy(bullet.gameObject);
        }


        if (myInputManagerScript != null)
            myInputManagerScript.quitPlayer(this);

        Destroy(this.gameObject);

    }

    private void OnQuit()
    {
        if (canQuit)
        {
            destroyPlayer();
        }



    }


}
