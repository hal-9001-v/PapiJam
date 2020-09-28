using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterSelector : MonoBehaviour
{
    public Sprite[] mySprites;
    public SpriteRenderer mySpriteRenderer;
    public PlayerController myPlayerController;
    public Vector2Int myPosition;

    private void Awake()
    {
        if (mySpriteRenderer == null)
        {
            mySpriteRenderer = GetComponent<SpriteRenderer>();

            if (mySpriteRenderer == null)
                Debug.LogWarning("No Sprite Renderer on " + gameObject.name);
        }
    }


    public void setCharacter(CharacterHolder holder)
    {
        transform.parent = holder.transform;

        Vector3 aux = holder.transform.position;
        aux.z -= 1;

        transform.position = aux;

        mySpriteRenderer.sprite = mySprites[myPlayerController.PlayerID];
    }


}
