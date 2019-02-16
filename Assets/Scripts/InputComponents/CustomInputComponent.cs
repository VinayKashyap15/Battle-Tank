using UnityEngine;
using Player;
using GameplayInterfaces;

namespace InputComponents
{
    /// <summary>
    /// custom input taken from the scriptable object 
    /// </summary>
    class CustomInputComponent : InputComponent
    {       

        public CustomInputComponent(InputScriptableObject _customInputScheme,ICharacterController _currentPlayerControllerInstance)
        {
            fireKey=_customInputScheme.fireKey;
            moveForwardKey=_customInputScheme.moveForwardKey;
            moveBackwardKey= _customInputScheme.moveBackwardKey;
            rotateLeftKey = _customInputScheme.moveLeftKey;
            rotateRightKey = _customInputScheme.moveRightKey;
            pauseKey=_customInputScheme.pauseKey;
            currentCharacterController = _currentPlayerControllerInstance;
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

        public override KeyCode GetRotateLeftInput()
        {
            return rotateLeftKey;
        }

        public override KeyCode GetRotateRightInput()
        {
            return rotateRightKey;
        }
        public  override KeyCode GetPauseKey()
        {
                return pauseKey;
        }
    }
}
