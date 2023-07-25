using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float checkpointActivationDistance; 
    GameManager gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() 
    {
        CheckPlayerProximity();
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

    void CheckPlayerProximity()
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y + 2f, 
                player.transform.position.z);
        Vector3 rayDirection = playerPosition - this.transform.position;
        Ray checkpointRay = new Ray(transform.position, rayDirection);
        //LayerMask ignoreLayers = LayerMask.GetMask("Buildings", "Roads", "Ground", "Default");
        LayerMask playerMask = LayerMask.GetMask("Player");
        RaycastHit hit;
        if(Physics.Raycast(checkpointRay, out hit, checkpointActivationDistance, playerMask))
        {
            Debug.DrawRay(transform.position, rayDirection);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
