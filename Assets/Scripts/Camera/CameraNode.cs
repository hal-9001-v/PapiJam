using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraNode : MonoBehaviour
{
    [Range(1, 10)]
    public float gizmosDrawRange = 1f;
    [Range(3, 20)]
    public float gizmosDrawLine = 3f;
    public float delay;
    public float timeToGet;

    //Eventos para nodos.
    public UnityEvent atStartEvent;
    public UnityEvent delayEvent;
    public UnityEvent atEndEvent;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gizmosDrawRange);
        Gizmos.DrawLine(transform.position, gizmosDrawLine * (transform.rotation * Vector3.forward)
            + transform.position);
    }
}
