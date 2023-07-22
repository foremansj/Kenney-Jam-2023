using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    SceneManager sceneManager;

    void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            Debug.Log("checkpoint reached");
            sceneManager.DisableFogOfWar(this.gameObject);
            Destroy(this.gameObject);
        }

    }


}
