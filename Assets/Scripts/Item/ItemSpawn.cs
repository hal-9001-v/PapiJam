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


    ItemSystem mySystem;

    
    public float timeUntilChange;
    public float movement;

    float animationTimer;

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
        animationTimer = 0;
        movement = Mathf.Abs(movement);
        myItem.itemSetActive(true);
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + spawnHeight, transform.position.z);
        myItem.transform.position = spawnPosition;
        StartCoroutine(spawnDelay());

    }

    public IEnumerator spawnDelay(){
        myItem.itemSetActive(false);
        yield return new WaitForSeconds(5f);
        myItem.itemSetActive(true);
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
            itemAnimation(myItem.transform);
        }
    }



    private void itemAnimation(Transform itemTransform)
    {
        myItem.transform.Rotate(rotationSpeed);

        if (animationTimer < timeUntilChange)
        {
            animationTimer += Time.deltaTime;

            itemTransform.position = new Vector3(itemTransform.position.x, itemTransform.position.y + movement, itemTransform.position.z);

        }
        else
        {
            movement = -movement;
            animationTimer = 0;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position + new Vector3(0, spawnHeight, 0), new Vector3(0.5f, 0.5f, 0.5f));
    }

}
