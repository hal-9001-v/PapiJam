using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CameraTransitioner : MonoBehaviour
{
    //Prefab del canvas.
    public GameObject transitionCanvas;
    public bool deleteEvents = true;

    //Eventos a realizar cuando la transición se encuentra en negro/blanco.
    public UnityEvent startTransition;
    public UnityEvent startDelay;
    public UnityEvent endDelay;
    public UnityEvent endTransition;

    //Auxiliares
    private float startTime;

    //TRANSICIONES
    //Transición a color mate.
    public void transitionToColor(float timeToGet, float delay, Color col)
    {
        if (transitionCanvas)
        {
            GameObject canvas = Instantiate(transitionCanvas, new Vector3(), Quaternion.identity);
            canvas.GetComponent<Canvas>().worldCamera = Camera.current;
            RawImage image = canvas.GetComponentInChildren<RawImage>();
            image.color = new Color(col.r, col.g, col.b, 0f);
            startTime = Time.realtimeSinceStartup;
            startTransition.Invoke();
            StartCoroutine(StartTransition(timeToGet, delay, canvas, image));
        }
    }
    IEnumerator StartTransition(float timeToGet, float delay, GameObject canvas, RawImage image)
    {
        while (image.color.a < 1)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b,
                (Time.realtimeSinceStartup - startTime) / timeToGet);
            yield return new WaitForEndOfFrame();
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        StartCoroutine(EndTransition(timeToGet, delay, canvas, image));
    }
    IEnumerator EndTransition(float timeToGet, float delay, GameObject canvas, RawImage image)
    {
        startDelay.Invoke();
        yield return new WaitForSeconds(delay);

        endDelay.Invoke();
        startTime = Time.realtimeSinceStartup;
        while (image.color.a > 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b,
                1f - ((Time.realtimeSinceStartup - startTime) / timeToGet));
            yield return new WaitForSeconds(Time.deltaTime);
        }
        endTransition.Invoke();
        if (deleteEvents) eraseAllEvents();
        Destroy(canvas);
    }

    public void eraseAllEvents()
    {
        startTransition.RemoveAllListeners();
        startDelay.RemoveAllListeners();
        endDelay.RemoveAllListeners();
        endTransition.RemoveAllListeners();
    }
}
