using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool hasTeleported = false;
    public bool isShowingColliderNames = true;
    private GameObject teleport;

    void Start()
    {
        
    }

    void Update(){
        
    }
    

    // Update is called once per frame
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(isShowingColliderNames){
            Debug.Log("Collider: " + hit.collider);
        }
    }

    private void OnTriggerEnter(Collider other) {     
        if(other.gameObject.TryGetComponent(out TeleportController controller)){
             Debug.Log("Se ha colisionado con gameobject que contiene TeleportController");
        }
    }

    public bool GetTeleported(){
        return hasTeleported;
    }

    public void SetTeleported(bool teleported){
        hasTeleported = teleported;
    }
}
