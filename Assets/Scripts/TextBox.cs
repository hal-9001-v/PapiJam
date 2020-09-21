using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextBox : MonoBehaviour
{
    public TextMeshProUGUI myText;
    [TextArea(0, 4)]
    public string[] message;
    public float delay;

    public UnityEvent startTextEvent;
    public UnityEvent endTextEvent;

    public TextBox nextTextBox;

    public bool pressToContinue;

    public KeyCode interactionKey;

    public bool atStart;

    private void Awake()
    {
        if (myText == null)
        {
            myText = GetComponent<TMPro.TextMeshProUGUI>();

            if (myText == null)
            {
                Debug.LogWarning("No TextMeshProUGUI attached to object");
            }

        }

        if (atStart)
        {
            showText();
            startTyping();
        }
        else
        {
            hideText();
        }

    }

    public void startTyping()
    {
        StartCoroutine(Type());
    }

    public void showText()
    {
        GetComponent<CanvasRenderer>().SetAlpha(1);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

        }

        gameObject.SetActive(true);

    }
    public void hideText()
    {
        GetComponent<CanvasRenderer>().SetAlpha(0);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        enabled = false;

    }

    IEnumerator Type()
    {
        showText();
        startTextEvent.Invoke();


        foreach (string line in message)
        {

            myText.text = "";
            foreach (char c in line.ToCharArray())
            {

                myText.text += c;

                //Sounds

                if (Input.GetKeyDown(interactionKey))
                {
                    myText.text = line;

                    yield return null;

                    goto EndOfTyping;
                }

                yield return new WaitForSeconds(delay);

            }
            
        EndOfTyping:

            if (pressToContinue)
            {
                while (!Input.GetKeyDown(interactionKey))
                {
                    yield return null;
                }

                yield return null;
            }

        }

        endTextEvent.Invoke();

        hideText();

        if (nextTextBox != null)
            nextTextBox.startTyping();
    }

}
