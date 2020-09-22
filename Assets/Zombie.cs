using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : Enemy
{
    float moveTimer;
    float attackTimer;

    bool readyToAttack;

    public float moveUpdateCD;
    public float attackCD;

    [Range(1f, 10)]
    public float attackRange;

    private new void Awake()
    {
        initializeEnemy();
        moveTimer = moveUpdateCD + 1;
    }

    private void Update()
    {
        
        moveTimer += Time.deltaTime;

        if (readyToAttack)
        {
            if (Vector3.Distance(currentTarget.position, transform.position) < attackRange)
            {
                hurtPlayer();
            }

        }
        else
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > attackCD)
            {
                readyToAttack = true;
                Debug.Log("ARMED");
                knockBack(new Vector3(200, 200, 200));


            }
        }

        if (myNavMesh.enabled)
        {
            if (moveTimer > moveUpdateCD)
            {
                moveTimer = 0;


                currentTarget = getNearest();
                myNavMesh.destination = currentTarget.position;
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void hurtPlayer()
    {
        readyToAttack = false;
        attackTimer = 0;

        //Do Some Stuff

    }

    protected override void die()
    {

    }
}
