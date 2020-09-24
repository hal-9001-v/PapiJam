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

        if (gamepad.dpad.up.wasPressedThisFrame || gamepad.leftStick.up.wasPressedThisFrame)
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
        if (gamepad.dpad.down.wasPressedThisFrame || gamepad.leftStick.down.wasPressedThisFrame)
        {
            charSelected = (charSelected + 2) % 4;
        }

        if (gamepad.dpad.left.wasPressedThisFrame || gamepad.leftStick.left.wasPressedThisFrame)
        {
            charSelected = (charSelected - 1);
            if (charSelected < 0)
            {
                charSelected = 3;
            }
        }

        if (gamepad.dpad.right.wasPressedThisFrame || gamepad.leftStick.right.wasPressedThisFrame)
        {
            charSelected = (charSelected + 1) % 4;
        }

        if (gamepad.aButton.wasPressedThisFrame)
        {
            isReady = true;
        }

        if (gamepad.bButton.wasPressedThisFrame)
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
