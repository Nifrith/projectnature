using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLightController : MonoBehaviour
{
    
    public GameObject parentObject;

    private Transform localTransform;

    private Light dayLight;
    private Transform[] ts;

    private float dayTime;
    private float lightIntensityVariation = 0.125f;

    void Start()
    {
        localTransform = gameObject.transform;
        dayLight = GetComponent<Light>();
        ts = parentObject.GetComponentsInChildren<Transform>();
        dayTime = 12f;
        changeIllumination(dayTime);
        Debug.Log(ts.Length);
    }

    void Update()
    {
        dayTime += 0.003f;
        if(Math.Truncate(dayTime) >= 24f){
            dayTime = 0f;
        }
        changeIllumination(dayTime);
    }

    void changeIllumination(float dayTime){

         dayTime = (float)Math.Truncate(dayTime);

        
         switch(dayTime){

             case 0:  localTransform.position = ts[5].position;
                      dayLight.intensity = lightIntensityVariation * 0;
                      break;

             case 3:  localTransform.position = ts[6].position;
                      dayLight.intensity = lightIntensityVariation * 0;
                      break;

             case 6:  localTransform.position = ts[7].position;
                      dayLight.intensity = lightIntensityVariation * 1;
                      break;

             case 9:  localTransform.position = ts[0].position;
                      dayLight.intensity = lightIntensityVariation * 3;
                      break;

             case 12: localTransform.position = ts[1].position;
                      dayLight.intensity = lightIntensityVariation * 4;
                      break;

             case 15: localTransform.position = ts[2].position;
                      dayLight.intensity = lightIntensityVariation * 3;
                      break;

             case 18: localTransform.position = ts[3].position;
                      dayLight.intensity = lightIntensityVariation * 2;
                      break;

             case 21: localTransform.position = ts[4].position;
                      dayLight.intensity = lightIntensityVariation * 1;
                      break;


         }   


    }

}
