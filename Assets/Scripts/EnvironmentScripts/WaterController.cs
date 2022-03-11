using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
 
 public AudioClip winSound;
 AudioSource audioSource;
 float volumeScale = 3f;


 void Start (){
     audioSource=gameObject.GetComponent<AudioSource>();
 }
 
 // Update is called once per frame
 void Update () 
 {

 }

 void OnTriggerEnter(Collider col)
 {
    Debug.Log("Entered water");


    audioSource.PlayOneShot(winSound, volumeScale);
  
 }
 
}