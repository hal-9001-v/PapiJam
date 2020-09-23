using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("Camera Switcher").GetComponent<CameraSwitcher>().enableCinematicCamera(2, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject.Find("Camera Switcher").GetComponent<CameraSwitcher>().enableMainCamera(2, 2);
            GameObject.Find("Camera Switcher").GetComponent<CameraSwitcher>().atEndEvent.
                AddListener(() => GameObject.Find("Main Virtual Camera").GetComponent<VirtualCameraController>().setPos(20f, 40f, 1, 0));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject.Find("Main Virtual Camera").GetComponent<VirtualCameraController>().setPos(5f, 30f, 2, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject.Find("Main Virtual Camera").GetComponent<VirtualCameraController>().setPos(20f, 40f, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 pos = new Vector3(10f, 0f, 0f) + GameObject.Find("Cinematic Camera").transform.position;
            Quaternion rot = Quaternion.Euler(GameObject.Find("Cinematic Camera").transform.rotation.eulerAngles
                + new Vector3(0f, 25f, 0f));
            GameObject.Find("Cinematic Camera").GetComponent<CinematicCameraController>().moveCamera(pos, rot, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject.Find("Cinematic Camera").GetComponent<CinematicCameraController>().goToNextNode();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject.FindWithTag("CameraTransitioner").GetComponent<CameraTransitioner>().endTransition.AddListener(() =>
            GameObject.FindWithTag("CameraTransitioner").GetComponent<CameraTransitioner>().transitionToColor(1, 0, Color.white));
            GameObject.FindWithTag("CameraTransitioner").GetComponent<CameraTransitioner>().transitionToColor(2, 1, Color.black);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject.FindWithTag("VirtualCamera").GetComponent<VirtualCamShake>().Shake(2);
            GameObject.FindWithTag("CinematicCamera").GetComponent<CamShake>().Shake(2);
        }
    }
}
