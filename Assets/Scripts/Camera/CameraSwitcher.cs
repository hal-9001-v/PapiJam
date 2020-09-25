using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraSwitcher : MonoBehaviour
{
    //Referencias
    public Camera mainCamera;
    public Camera cinematicCamera;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineTargetGroup targetGroup;

    //Cambio de cámara
    private float startTime;
    private Vector3 auxPos;
    private Quaternion auxRot;

    //Eventos para cambio de cámara.
    public UnityEvent atStartEvent;
    public UnityEvent delayEvent;
    public UnityEvent atEndEvent;

    public void enableMainCamera(float timeToGet, float delay)
    {
        if (!mainCamera.enabled)
        {
            goToMainCamera(cinematicCamera, mainCamera, timeToGet, delay);
        }
    }
    public void enableCinematicCamera(float timeToGet, float delay)
    {
        if (!cinematicCamera.enabled)
        {
            goToCinematicCamera(mainCamera, cinematicCamera, timeToGet, delay);
        }
    }
    
    //Transiciona a cámara principal moviendo la cámara cinemática.
    public void goToMainCamera(Camera start, Camera end, float timeToGet, float delay)
    {
        if (canSwitch())
        {
            if (timeToGet <= 0)
            {
                start.enabled = false;
                end.enabled = true;
            }
            else
            {
                goMoving();
                startTime = Time.realtimeSinceStartup;
                auxPos = start.transform.position;
                auxRot = start.transform.rotation;
                atStartEvent.Invoke();
                StartCoroutine(DoGoToMainCamera(start, end, timeToGet, delay));
            }
        }
    }

    //Transiciona a cámara cinemática simulando que la cámara principal se mueve (pero se mueve la cinemática).
    public void goToCinematicCamera(Camera start, Camera end, float timeToGet, float delay)
    {
        if (canSwitch())
        {
            start.enabled = false;
            end.enabled = true;

            if (timeToGet > 0)
            {
                goMoving();
                Vector3 endPos = end.transform.position;
                Quaternion endRot = end.transform.rotation; 
                end.transform.position = start.transform.position;
                end.transform.rotation = start.transform.rotation;
                startTime = Time.realtimeSinceStartup;
                auxPos = end.transform.position;
                auxRot = start.transform.rotation;
                atStartEvent.Invoke();
                StartCoroutine(DoGoToCinematicCamera(start, end, endPos, endRot, timeToGet, delay));
            }
        }
    }

    IEnumerator DoGoToMainCamera(Camera start, Camera end, float timeToGet, float delay)
    {
        while ((Vector3.Distance(start.transform.position, end.transform.position) > 0.05f) ||
        (Vector3.Distance(start.transform.rotation.eulerAngles, end.transform.rotation.eulerAngles) > 0.05f))
        {
            float t = (Time.realtimeSinceStartup - startTime) / timeToGet;
            start.transform.position = Vector3.Lerp(auxPos, end.transform.position, t);
            start.transform.rotation = Quaternion.Lerp(auxRot, end.transform.rotation, t);
            yield return new WaitForEndOfFrame();
        }

        delayEvent.Invoke();
        if (delay > 0) yield return new WaitForSeconds(delay);

        start.transform.position = auxPos;
        start.transform.rotation = auxRot;
        start.enabled = false;
        end.enabled = true;
        stopMoving();
        atEndEvent.Invoke();
    }

    IEnumerator DoGoToCinematicCamera(Camera start, Camera end, Vector3 endPos, Quaternion endRot, float timeToGet, float delay)
    {
        while ((Vector3.Distance(end.transform.position, endPos) > 0.05f) ||
        (Vector3.Distance(end.transform.rotation.eulerAngles, endRot.eulerAngles) > 0.05f))
        {
            float t = (Time.realtimeSinceStartup - startTime) / timeToGet;
            end.transform.position = Vector3.Lerp(auxPos, endPos, t);
            end.transform.rotation = Quaternion.Lerp(auxRot, endRot, t);
            yield return new WaitForEndOfFrame();
        }

        delayEvent.Invoke();
        if (delay > 0) yield return new WaitForSeconds(delay);

        end.transform.position = endPos;
        end.transform.rotation = endRot;
        stopMoving();
        atEndEvent.Invoke();
    }

    private void goMoving()
    {
        virtualCamera.gameObject.GetComponent<VirtualCameraController>().setMovingState(true);
        cinematicCamera.GetComponent<CinematicCameraController>().setMovingState(true);
    }

    private void stopMoving()
    {
        virtualCamera.gameObject.GetComponent<VirtualCameraController>().setMovingState(false);
        cinematicCamera.GetComponent<CinematicCameraController>().setMovingState(false);
    }
    public void eraseAllEvents()
    {
        atStartEvent.RemoveAllListeners();
        delayEvent.RemoveAllListeners();
        atEndEvent.RemoveAllListeners();
    }

    public void addFollowPlayer(GameObject go)
    {
        targetGroup.AddMember(go.transform, 1f, 0f);
    }
    public void removeFollowPlayer(GameObject go)
    {
        targetGroup.RemoveMember(go.transform);
    }

    //Metodos estáticos.
    public static bool canSwitch()
    {
        return !(GameObject.FindWithTag("VirtualCamera").GetComponent<VirtualCameraController>().getMovingState() ||
            GameObject.FindWithTag("CinematicCamera").GetComponent<CinematicCameraController>().getMovingState());
    }

    public static bool canMove()
    {
        return !(GameObject.FindWithTag("VirtualCamera").GetComponent<VirtualCameraController>().getMovingState() &&
            GameObject.FindWithTag("CinematicCamera").GetComponent<CinematicCameraController>().getMovingState());
    }

}
