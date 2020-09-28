using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScenario : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0) speed = 7;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        
    }
}
