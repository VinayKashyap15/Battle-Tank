using UnityEngine;
using EnemyStates;

namespace Enemy
{
    public class EnemyStateMachine
    {
        IEnemyState _currentState;
        EnemyController currentEnemyController;

        public EnemyStateMachine(EnemyController _currentController)
        {
            currentEnemyController = _currentController;

        }
        public void ChangeCurrentState(IEnemyState _newState)
        {
            if (currentEnemyController.previousState != null)
            { currentEnemyController.previousState.OnStateExit(); }
            
            currentEnemyController.previousState=currentEnemyController.currentState;
            currentEnemyController.currentState = _newState;
            _newState.OnStateEnter();
        }
    }
}