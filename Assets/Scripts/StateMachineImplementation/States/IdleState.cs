using UnityEngine;
using Player;

namespace PlayerStates
{
    public class IdleState : PlayerState
    {
        PlayerView _playerViewInstance;
        Animator _currentPlayerAnimator;
        public IdleState(PlayerView _currentPlayerView)
        {
            if(_playerViewInstance!=null)
            {
                _playerViewInstance=null;
            }
            _playerViewInstance=_currentPlayerView;
            OnStateEnter();

        }
        public override void OnStateEnter()
        {
           _currentPlayerAnimator = _playerViewInstance.GetAnimator();
        }
        public override void OnStateExit()
        {        
            _currentPlayerAnimator.SetBool("isIdle",false);

        }
        public override void OnStateUpdate()
        {            
            _currentPlayerAnimator.SetBool("isIdle",true);
        }
    }
}