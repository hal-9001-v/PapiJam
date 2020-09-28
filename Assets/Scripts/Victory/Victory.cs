using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    public float time;
    public PlayerController myPlayer;

    public Transform onStagePosition;
    public Transform stageObject;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerController>();

        if (myPlayer == null)
        {
            Debug.LogError("No player in Scene");

            SceneManager.LoadScene(0);
            return;
        }
        else
        {
            myPlayer.transform.position = onStagePosition.position;
            myPlayer.transform.parent = stageObject.transform;
            //myPlayer.transform.LookAt(new Vector3(0, 0, 1));

            StartCoroutine(timer());
        }
    }

    IEnumerator timer()
    {

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
