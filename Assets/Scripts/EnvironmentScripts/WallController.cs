using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    GameObject iceWall;
    private float triggerCounter = 0f;
    private float wallCounter = 0f;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        iceWall = GameObject.FindGameObjectWithTag("WallSpawn");
        Debug.Log(iceWall.name);
        scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(wallCounter > 0f){
            wallCounter -= Time.deltaTime;
        }
       else if(wallCounter <= 0){
           restoreIceWall();
       }
    }

    void OnTriggerStay(Collider other)
    {
        scale.y = 0.5f;
        triggerCounter += Time.deltaTime;
        Debug.Log(triggerCounter);
        if (triggerCounter >= 2f)
        {
            wallCounter = 6f;
            Debug.Log("La muralla se destruyo, tienes "+ wallCounter +" segundos");

            transform.localScale = scale;
            destroyIceWall();
        }

    }
    

    void OnTriggerExit()
    {
        triggerCounter = 0;
        
    }

    void destroyIceWall()
    {
        if(iceWall.activeSelf){
        iceWall.SetActive(false);
        }
    }

    void restoreIceWall()
    {
        if(iceWall.activeSelf == false){
            scale.y = 1f;
            iceWall.SetActive(true);
            transform.localScale = scale;
            wallCounter = 0f;
        }
        
    }
}