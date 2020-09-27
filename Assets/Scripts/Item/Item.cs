using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public float timeRoRespawn;

    public bool readyToRespawn;

    public ItemSpawn myItemSpawn;

    public static ItemSystem myItemSystem;

    MeshRenderer[] myRenderers;
    BoxCollider[] myColliders;

    private void Awake()
    {
        if (myItemSystem == null)
        {
            myItemSystem = FindObjectOfType<ItemSystem>();
        }

    }

    private void OnEnable()
    {

        myRenderers = GetComponentsInChildren<MeshRenderer>();

        if (myRenderers == null)
        {
            myRenderers = GetComponentsInChildren<MeshRenderer>(true);

            if (myRenderers == null)
            {
                Debug.Log("No Renderers Attached in " + gameObject.name + "!");
            }
        }

        myColliders = GetComponentsInChildren<BoxCollider>();

        if (myColliders == null)
        {
            myColliders = GetComponentsInChildren<BoxCollider>(true);

            if (myColliders == null)
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

        if (myColliders != null) {
            foreach (BoxCollider c in myColliders) {
                c.enabled = b;
            }
        }

        if (myRenderers != null)
        {
            foreach (MeshRenderer r in myRenderers)
            {
                r.enabled = b;
            }
        }

    }

    IEnumerator respawnTimer()
    {
        yield return new WaitForSeconds(timeRoRespawn);

        myItemSystem.enqueueItem(this);

    }


}
