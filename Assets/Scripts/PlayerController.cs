using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    Collider cl;
    public Rigidbody rb;
    Quaternion playerRotation = Quaternion.Euler(0, 0, 180);
    public Vector2 wasdInput;
    public Vector3 walkVelocity;
    public Vector3 lasWalkVel;
    private enum FacingDirection { North, South, East, West };
    FacingDirection facing = FacingDirection.South;
    public Vector3 prevWalkVelocity;
    public int id;
    public OrbitalScript os;
    PlayerController playerHit;

    //Control Booleans
    public bool canSwing = true;
    public bool canDash = true;
    public bool canMove = true;
    public bool canShoot = true;
    public bool isHit = true;

    //Player Stats
    public float DashCD;
    public float ShootCD;
    public float walkSpeed;
    public float rotateSpeed;

    //GOs
    SwordScript sword;

    private void Awake()
    {
        cl = GetComponent<Collider>();
        id = cl.GetInstanceID();
        rb = GetComponent<Rigidbody>();
        os = GetComponentInChildren<OrbitalScript>();
    }
    private void Start()
    {

        DashCD = 0.7f;
        ShootCD = 0.2f;
        walkSpeed = 6f;
        rotateSpeed = 8f;
    }
    private void Update()
    {
    }
    private void OnMovement(InputValue value)
    {
        if (canMove)
        {
            wasdInput = value.Get<Vector2>();
            ProcessInput();
        }
        else
        {
            wasdInput = Vector2.zero;
        }

    }


    private void OnShoot()
    {

        if (canShoot)
        {
            canShoot = false;
            os.Shoot();
        }

    }

    //id 1 = bullet, id 2 = sword
    public void Hit(float force, int id, Vector3 dir, float time)
    {
        isHit = true;
        canDash = false;
        canMove = false;
        canShoot = false;
        canSwing = false;

        if (id == 1)
        {
            rb.AddForce(dir * force);
            Debug.Log("BulletHit");
            StartCoroutine(HitStun(time));
        }
        else if (id == 2)
        {
            rb.AddForce(dir * force);
            Debug.Log("SwordHit");
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
            Debug.Log("HitWall");
            rb.velocity = Vector3.zero;
            canDash = true;
            canMove = true;
            canSwing = true;
            canShoot = true;
            isHit = false;
        }
    }



    private void OnMelee()
    {

        if ((sword != null || true) && canSwing)
        {
            Debug.Log("IsFuckinguUP");
            canSwing = false;
            canMove = false;
            sword = Instantiate(GameAssets.i.meleeAttack[0], new Vector3(transform.position.x, transform.position.y, transform.localPosition.z), transform.rotation);
            sword.player = this.gameObject.GetComponent<PlayerController>();
            sword.transform.parent = gameObject.transform;
            StartCoroutine(Slicing());
        }
    }

    IEnumerator Slicing()
    {
        rb.velocity = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            sword.transform.Rotate(0, 15, 0);
        }
        yield return new WaitForSeconds(0.45f);
        yield return new WaitForSeconds(0.1f);
        canMove = true;
        canSwing = true;

    }

    private void OnDash()
    {
        if (canDash)
        {
            canDash = false;
            Debug.Log("IsDashing!");
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
        yield return new WaitForSeconds(DashCD);
        canDash = true;
    }


    private void ProcessInput()
    {
        if (walkVelocity != Vector3.zero) lasWalkVel = walkVelocity;
        walkVelocity = Vector3.zero;

        float vval = 0f;
        if (wasdInput.y > 0f) { vval += 1f; }
        else if (wasdInput.y < 0f) { vval -= 1f; }

        float hval = 0f;
        if (wasdInput.x > 0f) { hval += 1f; }
        else if (wasdInput.x < 0f) { hval -= 1f; }

        if (vval != 0)
        {
            walkVelocity += Vector3.forward * vval * walkSpeed;
        }
        if (hval != 0)
        {
            walkVelocity += Vector3.right * hval * walkSpeed;
        }
    }

    private void CheckForFacingDirectionChange()
    {
        if (walkVelocity == Vector3.zero) { return; }
        if (walkVelocity.x == 0 || walkVelocity.y == 0)
        {
            ChangeFacingDirection(walkVelocity);
        }
        else
        {
            if (prevWalkVelocity.x == 0)
            {
                ChangeFacingDirection(new Vector3(walkVelocity.x, 0, 0));
            }
            else if (prevWalkVelocity.z == 0)
            {
                ChangeFacingDirection(new Vector3(0, 0, walkVelocity.z));
            }
            else
            {
                Debug.LogWarning("Unexpected walkVelocity value.");
                ChangeFacingDirection(walkVelocity);
            }
        }
    }

    private void ChangeFacingDirection(Vector3 dir)
    {

        if (dir.z != 0)
        {
            facing = (dir.z > 0) ? FacingDirection.North : FacingDirection.South;
        }
        if (dir.x != 0)
        {
            facing = (dir.x > 0) ? FacingDirection.East : FacingDirection.West;
        }

        transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-walkVelocity), rotateSpeed * Time.deltaTime);

    }

    private void LateUpdate()
    {
        if (wasdInput == Vector2.zero)
        {
            walkVelocity = Vector3.zero;
        }

        if (prevWalkVelocity != walkVelocity) { CheckForFacingDirectionChange(); }

        if (canMove)
        {
            rb.velocity = new Vector3(walkVelocity.x, rb.velocity.y, walkVelocity.z);
        }



    }






}
