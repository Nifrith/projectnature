using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(hit.transform.tag == "Enemy")
        {
            EnemyManager.KilledEnemy(hit.gameObject);
            hit.gameObject.SetActive(false);
        }
    }


    public bool GetTeleported(){
        return hasTeleported;
    }

    public void SetTeleported(bool teleported){
        hasTeleported = teleported;
    }
}
