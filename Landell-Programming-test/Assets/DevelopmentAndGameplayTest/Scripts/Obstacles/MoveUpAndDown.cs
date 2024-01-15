using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : Obstacle
{
    
    [SerializeField,Tooltip("Automatically takes heigh of object and move it max distance of y scale")] 
    private bool _isAutoDistance;

    
    private float _direction = 1f;
    private bool _flip;
    [SerializeField]private float _maxUpDistance;
    [SerializeField]private float _maxDownDistance;
    private Vector3 _currentPosition;


    private void Awake()
    {
        
        if(!_isAutoDistance)return;
        Vector3 localScale = transform.localScale;
        _maxUpDistance = localScale.y;
        _maxDownDistance = -localScale.y;
    }

    private void Update()
    {
        if(!_isActivated)return;
        
        MoveUpOrDown();
        SwitchDirection();
    }

    /// <summary>
    /// Moves Object Up or Down depending if the direction is negative or positive
    /// </summary>
    private void MoveUpOrDown()
    {
        transform.position += new Vector3(0, _direction * (_speed * Time.deltaTime), 0);
    }

    /// <summary>
    /// Flips Direction of Objects movement Direction
    /// </summary>
    /// <param name="currentPosition"></param>
    private void SwitchDirection()
    {
        _currentPosition = transform.position;
        
        _flip = _currentPosition.y >= _maxUpDistance || _currentPosition.y <= _maxDownDistance;

        if (!_flip) return;

        if (_currentPosition.y >= _maxUpDistance) _direction = -1;

        if (_currentPosition.y <= _maxDownDistance) _direction = 1;
    }
}
