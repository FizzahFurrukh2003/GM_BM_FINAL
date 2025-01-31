using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class playbtn : MonoBehaviour
{
    public GameObject SplashUI;
    public GameObject loadingscreen;
    public Slider slider;
    public float FakeLoadDuration = 3f;
   private float elapsedTime = 0f;



    public void LoadLevel()
    {
        Debug.Log("LoadLevel");
        StartCoroutine(LoadSceneAfterWait());
        SplashUI.SetActive(false);
        loadingscreen.SetActive(true);
        
       
    }


    IEnumerator LoadSceneAfterWait()
    {
        Debug.Log("nahi chala");
       
        while (elapsedTime < FakeLoadDuration)
        {
            float timepassed = Mathf.Lerp(0f, 1f, elapsedTime / FakeLoadDuration);
            slider.value = timepassed;
            elapsedTime += Time.deltaTime;

            if (timepassed >= 0.9f)
            {
                LoadMainScene();
            }
            yield return null;
            
            
        }
             
        
    }

    void LoadMainScene()
        {
            SceneManager.LoadScene(1);
        }

    
}
