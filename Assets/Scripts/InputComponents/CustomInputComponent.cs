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
            moveLeftKey = _customInputScheme.moveLeftKey;
            moveRightKey = _customInputScheme.moveRightKey;
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

        public override KeyCode GetMoveLeftInput()
        {
            return moveLeftKey;
        }

        public override KeyCode GetMoveRightInput()
        {
            return moveRightKey;
        }
        public  override KeyCode GetPauseKey()
        {
                return pauseKey;
        }
    }
}
