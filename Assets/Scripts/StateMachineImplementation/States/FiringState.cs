using UnityEngine;
using Player;

namespace PlayerStates
{
    public class FiringState : PlayerState
    {

        public FiringState(PlayerView _currentPlayerView)
        {
            OnStateEnter();
        }
        public override void OnStateEnter()
        {
            
        }
        public override void OnStateExit()
        {
           
            //disable firing animation
        }
        public override void OnStateUpdate()
        {
            //do something 
        }
    }
}