using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoInfinito : MonoBehaviour
{

    public GameObject[] cachitos;
    public Camera camara;
    public Quaternion rotacionCam;
    public bool changing;
    public int changeNum;
    // Start is called before the first frame update
    void Start()
    {
        rotacionCam = camara.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        camara.transform.rotation = Quaternion.Euler(Vector3.zero);
        camara.transform.Translate(Vector3.down * 30 * Time.deltaTime);
        camara.transform.rotation = rotacionCam;

        if (!changing)
        {
            StartCoroutine(Change(changeNum));
        }
        

    }

    IEnumerator Change(int num)
    {
        changing = true;
        cachitos[changeNum].transform.localPosition = cachitos[changeNum].transform.localPosition + new Vector3(0, -24.2f, 0);
        yield return new WaitForSeconds(30.2f);
        changeNum = (changeNum + 1) % 3;
        changing = false;
    }
}
