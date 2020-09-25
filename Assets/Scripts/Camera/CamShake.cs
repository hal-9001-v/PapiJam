using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public float intensity = 0.5f;
    private Transform target;
    private Vector3 lastShake = new Vector3();
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
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {
            target.localPosition -= lastShake;
            lastShake = new Vector3(Random.Range(-1, 1f) * intensity, Random.Range(-1f, 1f) * intensity, 0f);
            target.localPosition += lastShake;
            yield return null;
        }
        target.localPosition -= lastShake;
        pendingShakeDuration = 0f;
        isShaking = false;
    }
}
