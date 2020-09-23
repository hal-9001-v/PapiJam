using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerController player;

    public float swordForce = 150;
    public float hitStunTime = 1;

    public Vector3 dir;

    public float rotation = 15;

    public void attack()
    {
        gameObject.SetActive(true);

        StartCoroutine(Attack());
    }

    private void Awake()
    {
        gameObject.SetActive(false);

    }

    IEnumerator Attack()
    {


        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        player.rb.velocity = Vector3.zero;
        player.canMove = false;
        player.canSwing = false;

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(0, rotation, 0);
        }
        yield return new WaitForSeconds(0.55f);

        rotation = -rotation;

        player.canMove = true;
        player.canSwing = true;

        gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider col)
    {

        if ((col.gameObject.tag.Equals("Player")))
        {
            PlayerController hitPlayer = col.GetComponent<PlayerController>();

            if (hitPlayer != null)
            {
                dir = Vector3.Normalize(hitPlayer.transform.position - transform.position);

                hitPlayer.Hit(swordForce, dir, hitStunTime);

            }

        }

    }



}
