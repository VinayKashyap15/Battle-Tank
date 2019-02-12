using UnityEngine;
using GameplayInterfaces;

namespace EnemyStates
{
    public class ChaseState : EnemyState
    {
        ICharacterController playerToChase;
        ICharacterController enemyChasing;
        public ChaseState(ICharacterController _enemyChasing,ICharacterController _playerToChase)
        {
            enemyChasing=_enemyChasing;
            playerToChase=_playerToChase;
            OnStateEnter();
        }

        public override void OnStateEnter()
        {
            //throw new System.NotImplementedException();
            Debug.Log("Inside enemy chase state");            
        }

        public override void OnStateExit()
        {
            //throw new System.NotImplementedException();
        }

        public override void OnStateUpdate()
        {
            //throw new System.NotImplementedException();
           enemyChasing.SetNewLocation(Vector3.MoveTowards( enemyChasing.GetCurrentLocation(),playerToChase.GetCurrentLocation(),10f));
        }
    }
}