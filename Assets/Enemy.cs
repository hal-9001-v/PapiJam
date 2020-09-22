using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    protected NavMeshAgent myNavMesh;
    protected Rigidbody myRB;

    protected Transform[] targets;
    protected Transform currentTarget;

    public float health;
    public float knockBackMin = 0.5f;

    private bool isInKnockBack;

    protected void initializeEnemy()
    {
        myNavMesh = GetComponent<NavMeshAgent>();

        myRB = GetComponent<Rigidbody>();
        myRB.isKinematic = true;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        targets = new Transform[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            targets[i] = players[i].transform;
        }
    }

    protected void Awake()
    {
        initializeEnemy();
    }

    public void hurt(float dmg)
    {
        health -= dmg;

        if (health < 0)
        {
            die();
        }
    }

    protected abstract void die();

    protected void setPhysics(bool value)
    {
        myRB.isKinematic = !value;
        myNavMesh.enabled = !value;

    }

    public void knockBack(Vector3 dir)
    {
        setPhysics(true);

        myRB.AddForce(dir);

        isInKnockBack = true;
    }

    protected void checkKnockBack()
    {
        if (isInKnockBack && myRB.velocity.sqrMagnitude < knockBackMin)
        {
            isInKnockBack = false;
            setPhysics(false);
        }
    }

    protected void FixedUpdate()
    {
        checkKnockBack();
    }

    protected Transform getNearest()
    {
        Transform nearest = targets[0];

        float lowestDistance = Vector3.Distance(nearest.position, transform.position);
        float newDistance;

        for (int i = 1; i < targets.Length; i++)
        {
            newDistance = Vector3.Distance(targets[i].position, transform.position);

            if (newDistance < lowestDistance)
            {
                lowestDistance = newDistance;
                nearest = targets[i];
            }

        }

        return nearest;

    }

    protected Transform getFarthest()
    {

        Transform farthest = targets[0];

        float highestDistance = Vector3.Distance(farthest.position, transform.position);
        float newDistance;

        for (int i = 1; i < targets.Length; i++)
        {
            newDistance = Vector3.Distance(targets[i].position, transform.position);

            if (newDistance < highestDistance)
            {
                highestDistance = newDistance;
                farthest = targets[i];
            }

        }

        return farthest;
    }
}
