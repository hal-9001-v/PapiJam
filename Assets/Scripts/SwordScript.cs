using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerController myPlayer;

    public float swordForce = 150;
    public float hitStunTime = 1;
    public float limitCharge = 1;

    public BoxCollider swordCollider;
    public MeshFilter swordModel;
    public MeshRenderer swordMaterial;
    public Vector3 dir;

    public float rotation = 15;

    public void attack()
    {
        gameObject.SetActive(true);

        StartCoroutine(Attack());
    }

    private void Awake()
    {
        if (swordMaterial == null) swordMaterial = GetComponentInChildren<MeshRenderer>();
        if (swordCollider == null) swordCollider = GetComponent<BoxCollider>();
        if (swordModel == null) swordModel = GetComponentInChildren<MeshFilter>();
        gameObject.SetActive(false);

    }

    IEnumerator Attack()
    {
        transform.position = new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y, myPlayer.transform.position.z);

        myPlayer.rb.velocity = Vector3.zero;
        myPlayer.movementDirection = Vector3.zero;
        myPlayer.canMove = false;
        myPlayer.canSwing = false;

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(0, rotation, 0);
        }
        yield return new WaitForSeconds(0.55f);

        rotation = -rotation;

        myPlayer.canMove = true;
        myPlayer.canSwing = true;

        gameObject.SetActive(false);

    }

    public void setPlayer(PlayerController player)
    {
        myPlayer = player;
    }

    private void OnTriggerEnter(Collider col)
    {

        if ((col.gameObject.tag.Equals("Player")))
        {
            PlayerController hitPlayer = col.GetComponent<PlayerController>();

            if (hitPlayer != null)
            {
                dir = Vector3.Normalize(hitPlayer.transform.position - transform.position);

                hitPlayer.Hit(swordForce, dir, hitStunTime);

                if (myPlayer != null)
                {
                    myPlayer.changeLimit(limitCharge);
                }

            }

        }

    }



}
