using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionCollisioner : MonoBehaviour
{
    public GameObject father;

    private void OnTriggerEnter(Collider other)
    {
        father.GetComponent<Rigidbody>().velocity = Vector3.zero;
        father.GetComponent<ExecutionController>().wallLimitReached = true;
    }
}
