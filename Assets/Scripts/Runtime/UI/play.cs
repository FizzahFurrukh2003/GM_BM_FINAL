using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public GameObject pauseButton;  
    public GameObject playButton;   

    private bool isPaused = true;   
    
    public void Play()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;  
            pauseButton.SetActive(true);  
            playButton.SetActive(false);  
        }
    }
}


