using UnityEngine;
using Player;
using System;

namespace InputComponents
{
    /// <summary>
    /// Keyboard component for input
    /// </summary>
    public class KeyboardComponent : InputComponent
    {        
        public KeyboardComponent(PlayerController _playerControllerInstance)
        {           
            SetDefaultInputScheme();
            currentPlayerController = _playerControllerInstance;
        }

        private void SetDefaultInputScheme()
        {            
            fireKey=KeyCode.Space;
            moveForwardKey = KeyCode.W;
            moveBackwardKey=KeyCode.S;
            moveLeftKey = KeyCode.A;
            moveRightKey= KeyCode.D;
        }

        public override KeyCode GetFireInput()
        {
            return fireKey;
        }

        public override KeyCode GetMoveUpInput()
        {
            return moveForwardKey;
        }

        public override KeyCode GetMoveDownInput()
        {
            return moveBackwardKey;
        }

        public override KeyCode GetMoveLeftInput()
        {
            return moveLeftKey;
        }

        public override KeyCode GetMoveRightInput()
        {
            return moveRightKey;
        }

    }
}
