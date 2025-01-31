using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groom_Interaction : MonoBehaviour
{
    [SerializeField] private Animator _characterAnimator2;

    public void GroomAnimation()
    {
        _characterAnimator2.SetTrigger("StageReached");
    }

    public void GroomAnimation2()
    {
        _characterAnimator2.SetTrigger("StageReached2");
    }
}