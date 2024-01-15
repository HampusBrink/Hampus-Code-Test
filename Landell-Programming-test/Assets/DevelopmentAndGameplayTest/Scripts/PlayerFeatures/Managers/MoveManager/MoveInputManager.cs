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
    
    
}