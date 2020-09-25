using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    public float rotation ;
    // Start is called before the first frame update
    void Start()
    {
        rotation = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,rotation,0) * Time.deltaTime);
    }
}
