using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Obstacle
{
    private void Update()
    {
        if(!_isActivated) return;
        
        RotateObject();
    }

    private void RotateObject()
    {
        transform.Rotate(Vector3.up * (_speed * Time.deltaTime));
    }
}
