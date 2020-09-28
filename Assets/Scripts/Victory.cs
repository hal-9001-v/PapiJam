using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    public float time;
    public float spinnignSpeed;
    public CameraTransitioner cta;
    public GameObject playerLocator;
    public GameObject myPlayer;

    bool spin = false;

    private void Awake() {
        cta.transitionToColor(11.5f,0f, new Color(0,0,0,0));
    }
    // Start is called before the first frame update
    void Start()
    {   

    }

    public void NextScene()
    {
        SceneManager.LoadScene(3);
    }

    // Update is called once per frame
    void Update()
    {
       if (myPlayer == null)
        {
            myPlayer = FindObjectOfType<PlayerController>().gameObject;

            if (myPlayer != null)
            {
                myPlayer.transform.position = playerLocator.transform.position;

                spin = true;

            }

        }

    }

    private void FixedUpdate()
    {
        if (spin)
            myPlayer.transform.Rotate(new Vector3(0, spinnignSpeed, 0));
    }

}
