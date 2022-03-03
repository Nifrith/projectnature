using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerEnum : MonoBehaviour
{
    public Transform playerTransform;
    public EnemyBehaviour enemyBehaviour;
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
        switch (enemyBehaviour)
        {
            case EnemyBehaviour.looker: 
            
                            LookRotation(playerTransform);
                            break;

            case EnemyBehaviour.follower: 
                            MoveToPlayer(playerTransform);
                            break;
        }


    }


    void LookRotation(Transform whatToLook){
        transform.rotation = Quaternion.Lerp(transform.rotation, whatToLook.rotation, timeCount);
        transform.LookAt(playerTransform);
        timeCount = timeCount + Time.deltaTime;
    }

    void MoveToPlayer(Transform whatToChase){
         LookRotation(whatToChase);
        
        if(Vector3.Distance(transform.position, whatToChase.position) <= MaxDist){
         
         if (Vector3.Distance(transform.position, whatToChase.position) >= MinDist)
         {
 
             transform.position += transform.forward * MoveSpeed * Time.deltaTime;
 
         }
        }
         
    }

    public enum EnemyBehaviour
    {
        looker,
        follower
    }

}
    