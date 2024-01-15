using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveInputManager : MonoBehaviour
{
    //TODO: Create Run & Jump

    private void OnMove(InputValue value)
    {
        this.Move(value.Get<Vector2>());
    }

    private void OnJump()
    {
        this.Jump();
    }
    
    private void OnRun(InputValue value)
    {
        this.Run(value.Get<float>() > 0);
    }

    private void OnLook(InputValue value)
    {
        this.Look(value.Get<Vector2>());
    }
}