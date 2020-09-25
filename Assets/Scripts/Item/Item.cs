using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float timeRoRespawn;

    public bool readyToRespawn;

    public ItemSpawn myItemSpawn;

    public static ItemSystem myItemSystem;

    private void Awake()
    {
        if (myItemSystem == null)
        {
            myItemSystem = FindObjectOfType<ItemSystem>();
        }
    }

    public void consume()
    {
        myItemSpawn.consumeItem();
        myItemSpawn = null;

        StartCoroutine(respawnTimer());
    }

    IEnumerator respawnTimer()
    {
        yield return new WaitForSeconds(timeRoRespawn);

        myItemSystem.enqueueItem(this);

    }


}
