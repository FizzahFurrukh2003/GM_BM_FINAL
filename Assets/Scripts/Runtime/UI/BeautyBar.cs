using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeautyBar : MonoBehaviour
{
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetBeauty(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(0f);
    }

    public void SetMaxBeauty(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
  
  
}
