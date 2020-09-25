using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [Range(0.5f, 10)]
    public float spawnHeight;
    public float respawnTime;

    private Item myItem;

    public Vector3 rotationSpeed;

    public bool readyToRespawn;

    ItemSystem mySystem;

    private void Awake()
    {
        mySystem = FindObjectOfType<ItemSystem>();

        if (mySystem == null)
        {
            Debug.LogError("No Item System on Scene!");
        }
    }

    private void Start()
    {
        mySystem.getItem(this);
    }

    public void spawnItem(Item item)
    {
        myItem = item;
        item.myItemSpawn = this;

        myItem.itemSetActive(true);

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + spawnHeight, transform.position.z);

        myItem.transform.position = spawnPosition;

    }


    public void consumeItem()
    {
        myItem = null;
        StartCoroutine(cdRespawn());
    }

    IEnumerator cdRespawn()
    {
        yield return new WaitForSeconds(respawnTime);

        mySystem.getItem(this);
    }



    private void FixedUpdate()
    {
        if (myItem != null)
        {
            myItem.transform.Rotate(rotationSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position + new Vector3(0, spawnHeight, 0), new Vector3(0.5f, 0.5f, 0.5f));
    }

}
