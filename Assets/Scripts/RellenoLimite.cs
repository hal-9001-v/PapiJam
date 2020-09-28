using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RellenoLimite : MonoBehaviour
{
    public Image myImage;
    // Start is called before the first frame update
    private void Awake() {
        myImage = GetComponent<Image>();
    }
}
