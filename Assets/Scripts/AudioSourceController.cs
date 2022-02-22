using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    public AudioClip[] somemp3; //<---drag mp3 into the inspector here
    AudioSource audioSource;

    int index; 
    void Start()
    {
         // you need a reference to your component
         audioSource=gameObject.GetComponent<AudioSource>();
         index = somemp3.Length - 1;
         Debug.Log(index);

    }

    // Update is called once per frame
      // now you should be able to say this anywhere else in your code
    void Update(){
        changeSong();
   }

    void changeSong(){
        
        if (Input.GetKeyDown(KeyCode.O))
        {
             if(index > 0){
                index--;
            }
           
            audioSource.clip = somemp3[index];
            Debug.Log("Song playing: " + audioSource.clip.ToString());
            audioSource.pitch = .8f;
            audioSource.Play();
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(index <2){
                index++;
            }
            
           
            audioSource.clip = somemp3[index];
            Debug.Log("Song playing: " + audioSource.clip.ToString());
            audioSource.pitch = .8f;
            audioSource.Play();
        }

        

    }

}
