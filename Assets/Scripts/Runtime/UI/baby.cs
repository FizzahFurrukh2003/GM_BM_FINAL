using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class baby : MonoBehaviour
{
   void Start()
   {
      transform.DOScale(3f, 1f).SetLoops(-1, LoopType.Yoyo);
   }
}
