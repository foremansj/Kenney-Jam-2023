using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject respawnPoint;
    [SerializeField] GameObject player;

    // Update is called once per frame
    public void RespawnPlayer()
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
