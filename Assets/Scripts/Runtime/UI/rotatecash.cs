using System.Collections;
using System.Collections.Generic;
using UnityEngine;using DG.Tweening;

public class rotatecash : MonoBehaviour
{

    [SerializeField] public Vector3 rotation;

    private void Update()
    {
        transform.Rotate(rotation*Time.deltaTime);
    }
  
}
