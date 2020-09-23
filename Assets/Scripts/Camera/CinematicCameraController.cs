using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CinematicCameraController : MonoBehaviour 
{
    //Modo normal.
    private new Camera camera;
    private float startingSize;
    private float aspectRatio;

    //Modo cinemático.
    public bool repeatMode = false;
    public List<CameraNode> nodes;
    private Queue<CameraNode> nodeQueue;
    private Vector3 auxPos;
    private bool isMoving = false;
    private float startTime;

    //Eventos para cada movimiento (ocultos)
    public UnityEvent atStartEvent;
    public UnityEvent delayEvent;
    public UnityEvent atEndEvent;

    void Awake()
    {   //Nada más emplearse se comprueba si es viable el GameObject asociado.
        camera = GetComponent<Camera>();
        if (!camera) { Destroy(this); }
    }

    private void Start()
    {
        nodeQueue = new Queue<CameraNode>();
        foreach (CameraNode node in nodes)
        {
            nodeQueue.Enqueue(node);
        }
    }

    //Acciones
    public void goToNextNode()
    {
        if (nodeQueue.Count > 0) 
        {
            StopAllCoroutines();
            isMoving = true;
            CameraNode currentNode = nodeQueue.Dequeue();
            if (repeatMode) nodeQueue.Enqueue(currentNode);
            Vector3 startPos = camera.transform.position;
            Quaternion startRot = camera.transform.rotation;
            startTime = Time.realtimeSinceStartup;
            currentNode.atStartEvent.Invoke();
            StartCoroutine(DoGoToNextNode(startPos, startRot, currentNode));
        }
    }
    IEnumerator DoGoToNextNode(Vector3 startPos, Quaternion startRot, CameraNode node)
    {
        while ((Vector3.Distance(camera.transform.position, node.transform.position) > 0.05) ||
        (Vector3.Distance(camera.transform.rotation.eulerAngles, node.transform.rotation.eulerAngles) > 0.05))
        {
            camera.transform.position = Vector3.Lerp(startPos, node.transform.position,
                (Time.realtimeSinceStartup - startTime) / node.timeToGet);
            camera.transform.rotation = Quaternion.Lerp(startRot, node.transform.rotation,
                (Time.realtimeSinceStartup - startTime) / node.timeToGet);
            yield return new WaitForEndOfFrame();
        }

        node.delayEvent.Invoke();
        if(node.delay > 0) yield return new WaitForSeconds(node.delay);

        node.atEndEvent.Invoke();
        isMoving = false;
    }

    public void addNodeToQueue(CameraNode cn)
    {
        nodeQueue.Enqueue(cn);
    }

    public void moveCamera(Vector3 endPos, Quaternion endRot, float timeToGet, float delay)
    {
        StopAllCoroutines();
        isMoving = true;
        Vector3 startPos = camera.transform.position;
        Quaternion startRot = camera.transform.rotation;
        startTime = Time.realtimeSinceStartup;
        atStartEvent.Invoke();
        StartCoroutine(DoMoveCamera(startPos, startRot, endPos, endRot, timeToGet, delay));
    }

    IEnumerator DoMoveCamera(Vector3 startPos, Quaternion startRot, Vector3 endPos, Quaternion endRot, float timeToGet, float delay)
    {
        while ((Vector3.Distance(camera.transform.position, endPos) > 0.05) ||
        (Vector3.Distance(camera.transform.rotation.eulerAngles, endRot.eulerAngles) > 0.05))
        {
            camera.transform.position = Vector3.Lerp(startPos, endPos, (Time.realtimeSinceStartup - startTime) / timeToGet);
            camera.transform.rotation = Quaternion.Lerp(startRot, endRot, (Time.realtimeSinceStartup - startTime) / timeToGet);
            yield return new WaitForEndOfFrame();
        }

        delayEvent.Invoke();
        if(delay > 0) yield return new WaitForSeconds(delay);

        isMoving = false;
        atEndEvent.Invoke();
    }

    //Getters y setters
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
