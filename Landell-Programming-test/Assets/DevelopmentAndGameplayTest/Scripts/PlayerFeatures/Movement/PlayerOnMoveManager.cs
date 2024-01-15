using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnMoveManager : MonoBehaviour
{
    //TODO: Add Run & Jump

    #region Fields

    private CharacterController _cc;


    private Vector2 _moveDirection;
    private Vector3 _movePosition;
    
    
    [Header("Movement Stats")]
    [SerializeField] private float _walkSpeed = 7.5f;
    
    
    
    [Header("Physics Stats")]
    [SerializeField] private float _gravity = 20;
    

    #endregion
    
    #region Initialize Methods

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }
    
    #endregion


    #region Subscribe/Unsubscribe (OnEnable / OnDestroy)

    /// <summary>
    /// Subscribe to Events
    /// </summary>
    private void OnEnable()
    {
        MoveHandlerDataManager.OnMove += OnMove;
        
    }


    /// <summary>
    /// Unsubscribe to Events
    /// </summary>
    private  void OnDestroy()
    {
        MoveHandlerDataManager.OnMove -= OnMove;
        
    }

    #endregion


    #region MonoBehaviour

    private void Update()
    {
        PlayerMovement();
    }

    #endregion


    #region Custom Methods

    private void OnMove(Vector2 direction)
    {
        _moveDirection = direction;
    }
    
  

    
    private void PlayerMovement()
    {
        ApplyMoveSpeed();

        ApplyGravity();

        if(!_cc.enabled)return;
        
        _cc.Move(_movePosition * Time.deltaTime);
        
    }


    private void ApplyMoveSpeed()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 movement = ((forward * _moveDirection.y) + (right * _moveDirection.x)) * _walkSpeed;
        
        _movePosition = new Vector3(movement.x,_movePosition.y, movement.z);
    }


    private void ApplyGravity()
    {
        if(_cc.isGrounded) return;

        _movePosition.y -= _gravity * Time.deltaTime;
    }

    #endregion
    

    
}