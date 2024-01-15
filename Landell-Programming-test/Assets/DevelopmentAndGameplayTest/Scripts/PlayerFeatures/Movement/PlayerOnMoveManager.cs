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

    private bool _isGrounded = true;

    private float _mouseX;
    
    [Header("Body Parts")][SerializeField]
    private Transform _playerBody;

    [SerializeField] 
    private Transform _orientation;
    
    [SerializeField]
    private Transform _feet;
    
    [Header("Ground Check")] [SerializeField]
    private LayerMask _groundLayer;
    
     [SerializeField]
    private float _groundDistance;
    
    [Header("Movement Stats")] [SerializeField]
    private float _walkSpeed = 7.5f;

    [SerializeField]
    private float _runSpeed = 15f;
    
    [Header("Movement Stats")] [SerializeField]
    private float _jumpHeight = 3f;

    [Header("Physics Stats")] [SerializeField]
    private float _gravity = 20;
    
    [Header("Player Settings")] [SerializeField]
    private float _mouseSensitivity = 0.1f;


    #endregion

    #region Initialize Methods

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    #endregion


    #region Subscribe/Unsubscribe (OnEnable / OnDestroy)

    /// <summary>
    /// Subscribe to Events
    /// </summary>
    private void OnEnable()
    {
        MoveHandlerDataManager.OnMove += OnMove;
        MoveHandlerDataManager.OnJump += OnJump;
        MoveHandlerDataManager.OnRun += OnRun;
        MoveHandlerDataManager.OnLook += OnLook;
    }

    private void OnLook(Vector2 lookDir)
    {
        _mouseX -= lookDir.y * _mouseSensitivity;
        var mouseY = lookDir.x * _mouseSensitivity;
        _mouseX = Mathf.Clamp(_mouseX,-40f, 35f);
        
        _orientation.localRotation = Quaternion.Euler(_mouseX,0f,0f);
        _playerBody.Rotate(Vector3.up * mouseY);
    }

    private void OnJump()
    {
        if(_isGrounded)
            _movePosition.y = Mathf.Sqrt(_jumpHeight * -2f * -_gravity);
    }

    private void OnRun(bool isPressed)
    {
        //Doesn't get the default value of _walkSpeed
        _walkSpeed = isPressed ? _runSpeed : 7.5f;
    }


    /// <summary>
    /// Unsubscribe to Events
    /// </summary>
    private  void OnDisable()
    {
        MoveHandlerDataManager.OnMove -= OnMove;
        MoveHandlerDataManager.OnJump -= OnJump;
        MoveHandlerDataManager.OnRun -= OnRun;
        MoveHandlerDataManager.OnLook -= OnLook;
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

        _isGrounded = Physics.CheckSphere(_feet.position, _groundDistance, _groundLayer);

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