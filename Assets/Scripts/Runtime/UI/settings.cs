using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    public GameObject settingsUI;
    
    public void ToggleSetting()
    {
            settingsUI.SetActive(true);
            Time.timeScale = 0f;
    }
}
