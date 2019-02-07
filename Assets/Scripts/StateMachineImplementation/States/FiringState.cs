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
             Debug.Log("Exitting firing state of player");
            //disable firing animation
        }
        public override void OnStateUpdate()
        {
            //do something 
        }
    }
}