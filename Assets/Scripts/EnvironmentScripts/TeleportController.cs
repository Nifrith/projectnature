using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{

    public GameObject destination;
    Transform[] teleportSpawn;
    GameObject character;
    Transform spawnPoint;
    int index;
    CharacterCollisionController characterCollisionController;

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        characterCollisionController = character.GetComponent<CharacterCollisionController>();
        teleportSpawn = destination.GetComponentsInChildren<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.TryGetComponent(out CharacterCollisionController character))
        {   
            CharacterController controller = character.gameObject.GetComponent<CharacterController>();
            controller.enabled = false;

            if (character.GetTeleported() == false)
            {
                index = Random.Range(0, teleportSpawn.Length);
                spawnPoint = teleportSpawn[index].transform;
                character.transform.position = spawnPoint.position;
                character.transform.localScale /= 2.0f; 
                characterCollisionController.SetTeleported(true);
                Debug.Log("Teleported, size reduced");  
                controller.enabled = true;
            } else {
                index = Random.Range(0, teleportSpawn.Length);
                spawnPoint = teleportSpawn[index];
                character.transform.position = spawnPoint.position;
                character.transform.localScale *= 2.0f; 
                characterCollisionController.SetTeleported(false);
                Debug.Log("Teleported, size recovered");  
                controller.enabled = true;
            }                        
        }
    }
            



}
