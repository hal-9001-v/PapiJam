using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public float timeRoRespawn;

    public bool readyToRespawn;

    public ItemSpawn myItemSpawn;

    public static ItemSystem myItemSystem;

    MeshRenderer myRenderer;
    BoxCollider myCollider;

    private void Awake()
    {
        if (myItemSystem == null)
        {
            myItemSystem = FindObjectOfType<ItemSystem>();
        }

    }

    private void OnEnable()
    {

        myRenderer = GetComponent<MeshRenderer>();

        if (myRenderer == null)
        {
            myRenderer = GetComponentInChildren<MeshRenderer>(true);

            if (myRenderer == null)
            {
                Debug.Log("No Renderer Attached in " + gameObject.name + "!");
            }
        }

        myCollider = GetComponent<BoxCollider>();

        if (myCollider == null)
        {
            myCollider = GetComponentInChildren<BoxCollider>(true);

            if (myCollider == null)
            {
                Debug.Log("No Collider Attached in " + gameObject.name + "!");
            }

        }
    }

    public void consume()
    {
        myItemSpawn.consumeItem();
        myItemSpawn = null;

        itemSetActive(false);

        StartCoroutine(respawnTimer());
    }

    public void itemSetActive(bool b)
    {

        if (myCollider != null)
            myCollider.enabled = b;


        if (myRenderer != null)
            myRenderer.enabled = b;

    }

    IEnumerator respawnTimer()
    {
        yield return new WaitForSeconds(timeRoRespawn);

        myItemSystem.enqueueItem(this);

    }


}
