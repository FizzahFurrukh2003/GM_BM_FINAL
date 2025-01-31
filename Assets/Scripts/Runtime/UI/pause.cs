using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseButton; 
    public GameObject playButton;  

    private bool isPaused = false;  

   
    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;  
            pauseButton.SetActive(false); 
            playButton.SetActive(true);   
        }
    }
}
