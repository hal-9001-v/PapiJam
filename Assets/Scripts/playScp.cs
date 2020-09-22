using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playScp : MonoBehaviour
{
    public RawImage fondo;
    public bool play;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {

            subirFondo();
        }
    }

    private void subirFondo()
    {
        fondo.transform.position = Vector3.MoveTowards(fondo.transform.position, new Vector3(fondo.transform.position.x, 195, 0), 700 * Time.deltaTime);
    }

    public void setPlay()
    {
        play = !play;
    }
}
