using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    private Vector2 wasdInput;
    private Vector3 walkVelocity;
    private Vector3 lastPos;    
    public bool canSwing = true;
    public bool canDash = true;
    public bool canMove = true;

    public float  DashCD = 0.7f;
    public float walkSpeed = 6f;
        GameObject sword; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update() {
    }
    private void OnMovement(InputValue value)
    {
        if(canMove){
        wasdInput = value.Get<Vector2>();
        ProcessInput();
        } else {
            wasdInput = Vector2.zero;
        }
    }
    
    private void OnMelee(){
        
        if((sword != null || true)&& canSwing) { 
        Debug.Log("IsFuckinguUP");
        canSwing = false;
        canMove = false;
        sword = Instantiate(GameAssets.i.meleeAttack[0], new Vector3(transform.position.x, transform.position.y, transform.localPosition.z), transform.rotation);
        sword.transform.parent = gameObject.transform;
        StartCoroutine(Slicing());}
    }

    IEnumerator  Slicing(){
        rb.velocity = Vector3.zero;
          for(int i = 0; i< 5; i++){
        yield return new WaitForSeconds(0.1f);
        sword.transform.Rotate(0,15,0);
        }
        yield return new WaitForSeconds(0.45f);
        Destroy(sword);        
        yield return new WaitForSeconds(0.1f);
        canMove = true;
        canSwing = true;

    }

    private void OnDash(){
        if(canDash){
        canDash = false;
        Debug.Log("IsDashing!");
        StartCoroutine(SlowDashing());
        StartCoroutine(DashCDIng());
        }
    }

     IEnumerator  SlowDashing(){
          for(int i = 0; i< 5; i++){
        yield return new WaitForSeconds(0f);
        rb.transform.position += rb.velocity/5;
        yield return new WaitForSeconds(0.01f);
        
        }

    }
    IEnumerator DashCDIng(){
        yield return new WaitForSeconds(DashCD);
        canDash = true;
    }
    

    private void ProcessInput()
    {
        walkVelocity = Vector3.zero;

        float vval = 0f;
        if (wasdInput.y > 0f) { vval += 1f; }
        else if (wasdInput.y < 0f) { vval -= 1f; }

        float hval = 0f;
        if (wasdInput.x > 0f) { hval += 1f; }
        else if (wasdInput.x < 0f) { hval -= 1f; }

        if (vval != 0) { walkVelocity += Vector3.forward * vval * walkSpeed;
            lastPos = walkVelocity;
 }
        if (hval != 0) { walkVelocity += Vector3.right * hval * walkSpeed; 
            lastPos = walkVelocity;
        }
    }

    private void LateUpdate()
    {
        if(canMove){
        if (wasdInput == Vector2.zero) { walkVelocity = Vector3.zero;
 
}

        rb.velocity = new Vector3(walkVelocity.x, rb.velocity.y, walkVelocity.z);
    
    }
                    transform.rotation = Quaternion.LookRotation(-lastPos);     

    }
}
