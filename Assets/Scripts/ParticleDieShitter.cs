using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDieShitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public IEnumerator FUCKME(){
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FUCKME());
    }
}
