using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float checkpointActivationDistance; 
    GameManager gameManager;
    [SerializeField] ParticleSystem checkpointParticles;
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
            Vector3 thisPosition = this.transform.position;
            Instantiate(checkpointParticles, new Vector3(thisPosition.x, thisPosition.y - 1, thisPosition.z), Quaternion.Euler(-90, 0, 0));
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
