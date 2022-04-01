using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPanel : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void setUnpaused(){
        isGamePaused = false;
    }

}
