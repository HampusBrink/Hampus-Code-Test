using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : Obstacle
{
    [SerializeField] private bool _flip;
    private Quaternion _resetPosition;
    [SerializeField, Range(0,179)] private float _rotationAmount = 90f;
    private const float MAX_WAIT_TIL_RESET = 3f;

    private void Awake()
    {
        _resetPosition = transform.rotation;
    }

    private void Update()
    {
        if(!_isActivated) return;


        if (_flip)
        {
            _flip = !_flip;
            StartCoroutine(StartFlipCountDown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player")) return;
        
        Debug.Log(collision.gameObject.layer);

        
        StartCoroutine(StartFlipCountDown());
    }


    private IEnumerator StartFlipCountDown()
    {
        yield return new WaitForSecondsRealtime(1f);
        StartCoroutine(FlipPlatform());
    }


    private IEnumerator FlipPlatform()
    {
        bool flip = true;
        while (flip)
        {
            yield return new WaitForFixedUpdate();
            transform.Rotate(Vector3.forward * (_speed * Time.deltaTime));

            if (transform.rotation.z <= Mathf.Clamp((_rotationAmount / 180),-1, 1)) continue;

            flip = false;
            yield return new WaitForSecondsRealtime(MAX_WAIT_TIL_RESET);
            transform.rotation = _resetPosition;

        }
        
    }
}
