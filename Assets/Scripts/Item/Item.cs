using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public float timeRoRespawn;

    public bool readyToRespawn;

    public ItemSpawn myItemSpawn;

    public static ItemSystem myItemSystem;

    Renderer myRenderer;
    Collider myCollider;

    private void Awake()
    {
        if (myItemSystem == null)
        {
            myItemSystem = FindObjectOfType<ItemSystem>();
        }

        myRenderer = GetComponent<Renderer>();
        
        if (myRenderer == null) {
            Debug.Log("No Renderer Attached!");
        }

        myCollider = GetComponent<Collider>();

        if (myCollider == null)
        {
            Debug.Log("No Collider Attached!");
        }
    }

    public void consume()
    {
        myItemSpawn.consumeItem();
        myItemSpawn = null;

        itemSetActive(false);

        StartCoroutine(respawnTimer());
    }

    public void itemSetActive(bool b) {

        myCollider.enabled = b;
        myRenderer.enabled = b;

    }

    IEnumerator respawnTimer()
    {
        yield return new WaitForSeconds(timeRoRespawn);

        myItemSystem.enqueueItem(this);

    }


}
