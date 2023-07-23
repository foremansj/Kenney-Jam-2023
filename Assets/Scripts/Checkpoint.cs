using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            gameManager.DisableFogOfWar(this.gameObject);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
