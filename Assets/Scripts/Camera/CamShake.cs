using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public float intensity = 0.5f;
    private Transform target;
    private GameObject follow;
    private GameObject lookAt;
    private Vector3 initialPos;
    private float pendingShakeDuration = 0f;
    private bool isShaking = false;

    public void Start()
    {
        target = GetComponent<Transform>();
    }

    public void Shake(float duration)
    {
        if (duration > 0)
        {
            pendingShakeDuration += duration;
        }
    }

    private void Update()
    {
        if (pendingShakeDuration > 0 && !isShaking)
        {
            initialPos = target.localPosition;
            follow = GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow.gameObject;
            lookAt = GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt.gameObject;
            GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = null;
            GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = null;
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {

            target.localPosition = initialPos + new Vector3(Random.Range(-1, 1f) * intensity, Random.Range(-1f, 1f) * intensity, 0f);
            yield return null;

        }
        target.localPosition = initialPos;
        GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = follow.transform;
        GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = lookAt.transform;
        pendingShakeDuration = 0f;
        isShaking = false;
    }
}
