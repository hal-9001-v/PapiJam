using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public PlayerController myPlayer;

    [Range(0.5f, 10)]
    public float spawnHeight;

    public void spawnPlayer(PlayerController player)
    {
        myPlayer = player;

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + spawnHeight, transform.position.z);

        myPlayer.transform.position = spawnPosition;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + new Vector3(0, spawnHeight, 0), new Vector3(0.5f, 0.5f, 0.5f));
    }


}
