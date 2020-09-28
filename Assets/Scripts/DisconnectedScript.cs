using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisconnectedScript : MonoBehaviour
{

    public SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    private void Awake() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


}

