using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
      public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject inGameUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (isGamePaused == true)
            {
                Resume();
            } else if (isGamePaused == false){
                Pause();
            }
        }
    }

    void Resume(){
        inGameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    
    void Pause(){
        inGameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public static void BackToMain(){
        Time.timeScale = 1f;
        isGamePaused = false;        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
