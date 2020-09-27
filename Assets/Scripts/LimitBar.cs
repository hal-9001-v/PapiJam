using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitBar : MonoBehaviour
{
    public int priority;

    public Image myImage;
    public PlayerController myPlayer;

    public Sprite[] myIcons;
    public Sprite[] myNumbers;

    public Image myIconRenderer;
    public Image myNumberRenderer;

    //Player's attributes
    private float limit;
    private float limitMax;

    private void Awake()
    {
        if (myImage == null)
        {
            myImage = GetComponentInChildren<Image>();

            if (myImage == null)
            {
                Debug.LogWarning("No bar object is attached");
            }


        }


    }

    private void Start()
    {
        if (myPlayer == null)
            hide();
    }


    public void setLimit(float newLimit)
    {
        if (newLimit < 0)
        {
            limit = 0;
        }
        else
        {
            limit = newLimit;

        }

        myImage.fillAmount = getNormalizedValue();

    }

    public void assingLimitBar(PlayerController player)
    {
        myPlayer = player;
        limitMax = player.MAXLIMIT;

        myIconRenderer.sprite = myIcons[player.charSelected];
        myNumberRenderer.sprite = myNumbers[player.PlayerID - 1];

        setLimit(0);
    }

    private float getNormalizedValue()
    {
        return limit / limitMax;
    }

    public void show()
    {
        myImage.enabled = true;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

    }

    public void hide()
    {
        myImage.enabled = false;
        foreach (Transform child in transform)
        {
            if (child.gameObject != myImage.gameObject)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public static LimitBar getFreeLimitBar()
    {

        LimitBar selectedBar = null;

        foreach (LimitBar bar in FindObjectsOfType<LimitBar>())
        {
            if (bar.myPlayer == null)
            {
                if (selectedBar == null)
                {
                    selectedBar = bar;
                }
                else {
                    if (selectedBar.priority > bar.priority) {
                        selectedBar = bar;
                    }
                }

            }
        }


        return selectedBar;
    }
}
