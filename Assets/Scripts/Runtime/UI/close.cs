using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
   public GameObject SETTINGSUI;
   public void closesettings()
   {
      SETTINGSUI.SetActive(false);
      Time.timeScale = 1f;
   }
}
