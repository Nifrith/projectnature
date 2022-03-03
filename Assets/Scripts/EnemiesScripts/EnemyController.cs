using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform playerTransform;

    private float timeCount = 0.0f;

    void LateUpdate()
    {
        LookRotation(playerTransform);
    }

    void LookRotation(Transform whatToLook){
        transform.rotation = Quaternion.Lerp(transform.rotation, whatToLook.rotation, timeCount);
        transform.LookAt(playerTransform);
        timeCount = timeCount + Time.deltaTime;
    }

}
