using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public PlayerController myPlayer;
    GameObject particleSpawn;
    [Range(0.5f, 10)]
    public float spawnHeight;

    private void Awake() {
        particleSpawn = Instantiate(GameAssets.i.particles[1], gameObject.transform);
        particleSpawn.SetActive(false);
    }
    public void spawnPlayer(PlayerController player)
    {
        SoundManager.PlaySound(SoundManager.Sound.Reaparecer, 0.4f);
        myPlayer = player;
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + spawnHeight, transform.position.z);

        myPlayer.transform.position = spawnPosition;
        particleSpawn.SetActive(true);
        StartCoroutine(SpawnParticle());
    }

    IEnumerator SpawnParticle(){
        yield return new WaitForSeconds(4);
        particleSpawn.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + new Vector3(0, spawnHeight, 0), new Vector3(0.5f, 0.5f, 0.5f));
    }

    public static PlayerSpawn getFreeSpawn()
    {
        foreach (PlayerSpawn ps in FindObjectsOfType<PlayerSpawn>())
        {
            if (ps.myPlayer == null)
            {
                return ps;
            }
        }

        return null;
    }

}
