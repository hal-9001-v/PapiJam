using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitBar : MonoBehaviour
{
    public Image myBar;
    
    //Player's attributes
    public float limit;
    public float limitMax;

    private void Awake()
    {
        if (myBar == null) {
            Debug.LogWarning("No bar object is attached");
        }
    }

    // Update is called once per frame
    void Update()
    {
        myBar.fillAmount = getNormalizedValue();
    }

    private float getNormalizedValue() {
        return limit / limitMax;
    }

    public void show() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
        gameObject.SetActive(true);
    }

    public void hide()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
