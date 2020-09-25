using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    public int playerID;
    PlayerController player;
    private void Awake() {
        player = GetComponentInParent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerID = player.PlayerID;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
