using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public Transform playerTransform;
    private float timeCount = 0.0f;
     int MoveSpeed = 4;
     int MaxDist = 10;
     int MinDist = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer(playerTransform);
    }
    
    void MoveTowardsPlayer(Transform whatToChase){
        transform.rotation = Quaternion.Lerp(transform.rotation, whatToChase.rotation, timeCount);
        transform.LookAt(whatToChase);
 
         if(Vector3.Distance(transform.position, whatToChase.position) <= MaxDist){
         
         if (Vector3.Distance(transform.position, whatToChase.position) >= MinDist)
         {
 
             transform.position += transform.forward * MoveSpeed * Time.deltaTime;
 
         }
        }
    }
}
