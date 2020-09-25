using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    static ItemSystem instance;

    public GameObject BFGPrefab;
    public int bfgNumber;

    public GameObject shieldPrefab;
    public int shieldNumber;

    public GameObject carPrefab;
    public int carNumber;

    public GameObject monsterPrefab;
    public int monsterNumber;

    public GameObject cloudPrefab;
    public int cloudNumber;

    public GameObject ramboPrefab;
    public int ramboNumber;

    public GameObject sonicPrefab;
    public int sonicNumber;

    public GameObject ultraPrefab;
    public int ultraNumber;

    List<Item> myReadyList;

    Queue<ItemSpawn> myItemSpawnQueue;


    private void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }


        myReadyList = new List<Item>();
        myItemSpawnQueue = new Queue<ItemSpawn>();

        instancePrefab(bfgNumber, BFGPrefab);
        instancePrefab(shieldNumber, shieldPrefab);
        instancePrefab(carNumber, carPrefab);
        instancePrefab(monsterNumber, monsterPrefab);
        instancePrefab(cloudNumber, cloudPrefab);
        instancePrefab(ramboNumber, ramboPrefab);
        instancePrefab(sonicNumber, sonicPrefab);
        instancePrefab(ultraNumber, ultraPrefab);

    }

    private void instancePrefab(int number, GameObject prefab)
    {
        if (prefab != null)
        {
            if (number > 0)
            {
                for (int i = 0; i < number; i++)
                {
                    myReadyList.Add(Instantiate(prefab, Vector3.zero, Quaternion.identity).GetComponent<Item>());
                }

            }
        }

    }

    public void getItem(ItemSpawn itemSpawn)
    {
        if (myReadyList.Count != 0)
        {

            int selection = Random.Range(0, myReadyList.Count);

            itemSpawn.spawnItem(myReadyList[selection]);
            myReadyList.RemoveAt(selection);
        }
        else
        {

            myItemSpawnQueue.Enqueue(itemSpawn);

        }
    }

    public void enqueueItem(Item item)
    {
        myReadyList.Add(item);

    }

    private void Update()
    {
        if (myItemSpawnQueue.Count != 0 && myReadyList.Count != 0)
        {
            getItem(myItemSpawnQueue.Dequeue());
        }
    }

}
