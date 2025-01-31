using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.TextCore.Text;

public class BounceFade : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    public TextMeshProUGUI textElement2;
    public float FadeDuration = 1f;
    public float BounceDuration = 0.5f;
    public float BounceScale = 1.2f;
    public float Delay = 0.3f;
private Vector3 originalScale;
    private void Start()
    {
        originalScale = textElement.transform.localScale;
        
        textElement.alpha = 0;
        textElement.transform.localScale = originalScale * 0.5f;
        
        textElement2.alpha = 0;
        textElement2.transform.localScale = originalScale * 0.5f;
        
        AnimateText();
        
    }

    void AnimateText()
    {
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(textElement.DOFade(1, FadeDuration));
        sequence.Join(textElement.transform.DOScale(originalScale * BounceScale, BounceDuration).SetEase(Ease.OutBack));
        sequence.Append(textElement.transform.DOScale(originalScale , 0.2f));

        sequence.AppendInterval(Delay);
        sequence.AppendCallback(() => AnimateText2());
    }

    void AnimateText2()
    {
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(textElement2.DOFade(1, FadeDuration));
        sequence.Join(textElement2.transform.DOScale(originalScale * BounceScale, BounceDuration).SetEase(Ease.OutBack));
        sequence.Append(textElement2.transform.DOScale(originalScale , 0.2f)); 
    }


    void AnimateText3()
    {
      
    }
}
