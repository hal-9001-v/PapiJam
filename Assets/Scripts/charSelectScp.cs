using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class charSelectScp : MonoBehaviour
{
    public int charSelected;
    public Sprite[] selectorSP;
    public Vector3[] casillasPos;
    public bool isReady;

    public Gamepad gamepad;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        if (!GameObject.Find("Selector1"))
        {
            this.name = "Selector1";
            spr.sprite = selectorSP[0];
            charSelected = 0;
            gamepad = Gamepad.all[0];

 
        }
        else if (!GameObject.Find("Selector2"))
        {
            this.name = "Selector2";
            spr.sprite = selectorSP[1];
            charSelected = 1;
            gamepad = Gamepad.all[1];
        }
        else if (!GameObject.Find("Selector3"))
        {
            this.name = "Selector3";
            spr.sprite = selectorSP[2];
            charSelected = 2;
            gamepad = Gamepad.all[2];
        }
        else
        {
            this.name = "Selector4";
            spr.sprite = selectorSP[3];
            charSelected = 3;
            gamepad = Gamepad.all[3];
        }

    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < casillasPos.Length; i++)
        {
            casillasPos[i] = GameObject.Find("Main Camera").transform.GetChild(1).transform.GetChild(0).transform.GetChild(i).transform.TransformPoint(Vector3.zero);
        }

        if (name == "Selector1")
        {
            transform.position = casillasPos[charSelected] + new Vector3(-1.7f, 1.7f, -1f);
        }
        else if (name == "Selector2")
        {
            transform.position = casillasPos[charSelected] + new Vector3(1.7f, 1.7f, -1f);
        }
        else if (name == "Selector3")
        {
            transform.position = casillasPos[charSelected] + new Vector3(-1.7f, -1.7f, -1f);
        }
        else
        {
            transform.position = casillasPos[charSelected] + new Vector3(1.7f, -1.7f, -1f);
        }

        if (gamepad.dpad.up.wasReleasedThisFrame|| gamepad.leftStick.up.wasReleasedThisFrame)
        {
            if (charSelected < 2)
            {
                charSelected += 2;
            }
            else
            {
                charSelected -= 2;
            }
        }
        if (gamepad.dpad.down.wasReleasedThisFrame || gamepad.leftStick.down.wasReleasedThisFrame)
        {
            charSelected = (charSelected + 2) % 4;
        }

        if (gamepad.dpad.left.wasReleasedThisFrame|| gamepad.leftStick.left.wasReleasedThisFrame)
        {
            charSelected = (charSelected - 1);
            if (charSelected < 0)
            {
                charSelected = 3;
            }
        }

        if (gamepad.dpad.right.wasReleasedThisFrame|| gamepad.leftStick.right.wasReleasedThisFrame)
        {
            charSelected = (charSelected + 1) % 4;
        }

        if (gamepad.aButton.wasReleasedThisFrame)
        {
            isReady = true;
        }

        if (gamepad.bButton.wasReleasedThisFrame)
        {
            isReady = false;
        }
    }

    private void OnRight()
    {
        
    }

    private void OnLeft()
    {
        
    }

    private void OnDown()
    {
        
    }

    private void OnUp()
    {
        
    }
}
