using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    public float time;
    public float spinnignSpeed;

    public GameObject playerLocator;
    public GameObject myPlayer;

    bool spin = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());

    }

    IEnumerator timer()
    {

        yield return new WaitForSeconds(time);

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
