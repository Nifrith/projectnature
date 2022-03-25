using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{ 
    public static SoundManager instance;
    public static AudioClip overworld;
    private static AudioClip[] battle;
    private static AudioSource[] _audioSource;
    static Scene currentScene;
    private void Awake()
    {
        if(SoundManager.instance == null){
            
          SoundManager.instance = this;
          DontDestroyOnLoad(gameObject);
         _audioSource = GetComponents<AudioSource>();

        } else {

            Destroy(gameObject);

        }
         
    }
 
    public static void PlayMusic()
    {    
        // Create a temporary reference to the current scene.
         currentScene = SceneManager.GetActiveScene ();

         

          // Retrieve the index of the scene in the project's build settings.
         int buildIndex = currentScene.buildIndex;
 
         // Check the scene name as a conditional.
         switch (buildIndex)
         {
         // overworld scene: battle music have to end
         case 0:
              StopMusic(1);
              _audioSource[buildIndex].pitch = 0.8f;
              _audioSource[buildIndex].Play();
             break;
         // Battle scene : overworld music should be pause   
         case 1:
              PauseMusic(0);
              int index = Random.Range (0, battle.Length);
              _audioSource[buildIndex].clip = battle[index];
              _audioSource[buildIndex].Play();
             break;
         }
    }
 
    public static void PauseMusic(int index)
    {
        _audioSource[index].Pause();
    }

    public static void StopMusic(int index)
    {
        _audioSource[index].Stop();
    }

}
