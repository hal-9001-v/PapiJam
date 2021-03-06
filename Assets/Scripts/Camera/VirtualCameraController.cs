﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class VirtualCameraController : MonoBehaviour
{
    public float mainDistance;
    public float mainAngle;
    private CinemachineFramingTransposer transposer;
    private bool isMoving = false;
    private Vector3 auxPos;
    private float startTime;

    //Eventos para cada movimiento (ocultos)
    public UnityEvent atStartEvent;
    public UnityEvent delayEvent;
    public UnityEvent atEndEvent;

    // Start is called before the first frame update
    void Start()
    {
        transposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        setPos(mainDistance, mainAngle, 0, 0);
    }

    public void setPos(float d, float r, float timeToGet, float delay)
    {
        if (CameraSwitcher.canMove())
        {
            StopAllCoroutines();
            if (timeToGet <= 0)
            {
                transposer.m_TrackedObjectOffset.y = d * Mathf.Sin(Mathf.Deg2Rad * r);
                transposer.m_TrackedObjectOffset.z = -d * Mathf.Cos(Mathf.Deg2Rad * r);
            }
            else
            {
                isMoving = true;
                startTime = Time.realtimeSinceStartup;
                auxPos = transposer.m_TrackedObjectOffset;
                atStartEvent.Invoke();
                StartCoroutine(DoSetPos(new Vector3(transposer.m_TrackedObjectOffset.x, d * Mathf.Sin(Mathf.Deg2Rad * r),
                    -d * Mathf.Cos(Mathf.Deg2Rad * r)), timeToGet, delay));
            }
        }
    }

   

    IEnumerator DoSetPos(Vector3 end, float timeToGet, float delay)
    {
        while (Vector3.Distance(transposer.m_TrackedObjectOffset, end) > 0.05)
        {
            transposer.m_TrackedObjectOffset = Vector3.Lerp(auxPos, end, (Time.realtimeSinceStartup - startTime) / timeToGet);
            yield return new WaitForEndOfFrame();
        }

        delayEvent.Invoke();
        if (delay > 0) yield return new WaitForSeconds(delay);

        transposer.m_TrackedObjectOffset = end;
        isMoving = false;
        atEndEvent.Invoke();
    }
    public bool getMovingState()
    {
        return isMoving;
    }

    public void setMovingState(bool state)
    {
        isMoving = state;
    }

    public void eraseAllEvents()
    {
        atStartEvent.RemoveAllListeners();
        delayEvent.RemoveAllListeners();
        atEndEvent.RemoveAllListeners();
    }
}
