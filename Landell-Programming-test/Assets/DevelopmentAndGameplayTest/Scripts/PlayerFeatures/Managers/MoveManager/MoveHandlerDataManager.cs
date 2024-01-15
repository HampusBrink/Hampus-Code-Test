using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveHandlerDataManager
{
    //TODO: Add Run & Jump

    #region Events
    
    public static event Action<Vector2> OnMove;
    


    #endregion
    


    #region Invoke Methods
    
    public static void Move(this MoveInputManager moveInputManager, Vector2 direction) => OnMove?.Invoke(direction);
    
    #endregion

}