using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextBox : MonoBehaviour
{
    private TextMeshProUGUI myText;
    public string message;
    public float delay;

    public UnityEvent startTextEvent;
    public UnityEvent endTextEvent;

    private void Awake()
    {
        myText = GetComponent<TMPro.TextMeshProUGUI>();

        if (myText == null)
        {
            Debug.LogWarning("No TextMeshProUGUI attached to object");
        }

        startTyping();
    }

    public void startTyping()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        startTextEvent.Invoke();
        myText.text = "";
        foreach (char c in message.ToCharArray())
        {

            myText.text += c;

            yield return new WaitForSeconds(delay);
        }

        endTextEvent.Invoke();

        yield return null;
    }
}
