using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{

    public Sprite[] sprites;
    private SpriteRenderer mySpriteRenderer;
    private PlayerInputManagerScript myInputManager;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myInputManager = FindObjectOfType<PlayerInputManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (myInputManager.playerNum)
        {
            case 0:
                break;
            case 1:
                mySpriteRenderer.sprite = sprites[0];
                break;


            case 2:
                mySpriteRenderer.sprite = sprites[1];
                break;


            case 3:
                mySpriteRenderer.sprite = sprites[2];
                break;


            case 4:
                mySpriteRenderer.sprite = sprites[3];
                break;

            default:
                Debug.LogWarning("More than 4 players!");
                break;
        }


    }
}
