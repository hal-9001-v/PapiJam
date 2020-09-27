﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

    public float timer;
    
    private void Awake() {
        StartCoroutine(DestroyParticles());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    IEnumerator DestroyParticles(){
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
