using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class propsupanddown : MonoBehaviour
{
   public float moveDistance = 1f;
   public float moveDuration = 2f;

   void Start()
   {
      MoveUpandDown();
   }

   void MoveUpandDown()
   {
      transform.DOMoveY(transform.position.y + moveDistance, moveDuration)
         .SetEase(Ease.InOutSine)
         .SetLoops(-1, LoopType.Yoyo);
         
   }
}
