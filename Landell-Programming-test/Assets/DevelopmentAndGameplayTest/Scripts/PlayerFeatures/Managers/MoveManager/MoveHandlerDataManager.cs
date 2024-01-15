using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveHandlerDataManager
{
    //TODO: Add Run & Jump

    #region Events
    
    public static event Action<Vector2> OnMove;
    public static event Action OnJump;
    public static event Action<bool> OnRun;
    public static event Action<Vector2> OnLook;
    


    #endregion
    


    #region Invoke Methods
    
    public static void Move(this MoveInputManager moveInputManager, Vector2 direction) => OnMove?.Invoke(direction);
    public static void Jump(this MoveInputManager moveInputManager) => OnJump?.Invoke();
    public static void Run(this MoveInputManager moveInputManager, bool isPressed) => OnRun?.Invoke(isPressed);
    public static void Look(this MoveInputManager moveInputManager, Vector2 lookDir) => OnLook?.Invoke(lookDir);
    
    #endregion

}