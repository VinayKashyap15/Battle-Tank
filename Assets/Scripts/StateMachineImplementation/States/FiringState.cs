using UnityEngine;
using Player;

namespace PlayerStates
{
    public class FiringState : PlayerState
    {
        PlayerView _playerViewInstance;
        public FiringState(PlayerView _currentPlayerView)
        {
            _playerViewInstance=_currentPlayerView;
            OnStateEnter();
        }
        public override void OnStateEnter()
        {
            
        }
        public override void OnStateExit()
        {
            
        }
        public override void OnStateUpdate()
        {
            //do something 
        }
    }
}