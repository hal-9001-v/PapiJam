using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCamShake : MonoBehaviour
{
    public float intensity = 0.5f;
    private CinemachineTransposer target;
    private Vector3 lastShake = new Vector3();
    private float pendingShakeDuration = 0f;
    private bool isShaking = false;

    public void Start()
    {
        target = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
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
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {
            target.m_FollowOffset -= lastShake;
            lastShake = new Vector3(Random.Range(-1, 1f) * intensity, Random.Range(-1f, 1f) * intensity, 0f);
            target.m_FollowOffset += lastShake;
            yield return null;
        }
        target.m_FollowOffset -= lastShake;
        pendingShakeDuration = 0f;
        isShaking = false;
    }
}
