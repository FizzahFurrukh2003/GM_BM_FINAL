using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
public class Player_Movement : MonoBehaviour
{
     public GameObject gameObject1;
    public CharacterController _characterController;

    public Player_Interaction player_Interaction;
    private float _moveSpeed = 5.0f;
    private bool _isMoving = false;
    private UnityEngine.Vector3 _moveDirection;
    public bool restrictmovement = false;

   void Start()
    {
            _characterController = GetComponent<CharacterController>();  
            player_Interaction = GetComponent<Player_Interaction>();
         
    }

    public void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.W) && !_isMoving)
        {
            restrictmovement = false;
            _isMoving = true;
            player_Interaction.StartWalking();
            _moveDirection = transform.forward;
        }

        if (_isMoving)
        {
            if (restrictmovement)
            {
                _characterController.Move(_moveDirection * (_moveSpeed * Time.deltaTime));
                player_Interaction.StartWalking();
                _moveDirection = transform.forward;
            }
            else
            {
                _characterController.Move(_moveDirection * (_moveSpeed * Time.deltaTime));
                _moveDirection = transform.forward;
                float horizontalInput = Input.GetAxis("Horizontal");
                UnityEngine.Vector3 horizontalMovement =transform.right * (horizontalInput * _moveSpeed * Time.deltaTime);
                _characterController.Move(horizontalMovement);
            }
        }
    }

    public void StopMovement()
    {
        _isMoving = false;
        _moveDirection = UnityEngine.Vector3.zero;
    }

    public IEnumerator WaitAndResumeMovement()
    {
        yield return new WaitForSeconds(3f);
        _isMoving = true;
        player_Interaction.StartWalking();
        _moveDirection = transform.forward;
        restrictmovement = true;
       

    }
    
    
}

