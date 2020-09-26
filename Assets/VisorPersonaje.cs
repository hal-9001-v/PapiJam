using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisorPersonaje : MonoBehaviour
{
    public int characterSelected;
    public int numChar;
    public GameObject selector;
    public Sprite[] charactersPics;
    // Start is called before the first frame update
    void Start()
    {
        numChar = GameObject.Find("Main Camera").GetComponent<MenuManager>().playersNum;
        

    }

    // Update is called once per frame
    void Update()
    {
        setVisor();

        GetComponent<SpriteRenderer>().sprite = charactersPics[selector.gameObject.GetComponent<charSelectScp>().charSelected];
    }

    void setVisor()
    {
        if (name == "Personaje")
        {
            selector = GameObject.Find("Selector1");
        }
        else if (name == "Personaje (1)")
        {
            selector = GameObject.Find("Selector2");
        }
        else if (name == "Personaje (2)" && numChar >= 3)
        {
            selector = GameObject.Find("Selector3");
        }
        else if (name == "Personaje (3)" && numChar == 4)
        {
            selector = GameObject.Find("Selector4");
        }
    }
}
