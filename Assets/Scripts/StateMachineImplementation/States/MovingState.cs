using UnityEngine;

namespace PlayerStates
{
    public class MovingState: PlayerState
    {
          public MovingState(Player.PlayerView _currentPlayerView)
        {
            OnStateEnter();

        }
        public override void OnStateEnter()
        {
            
        }
        public override void OnStateExit()
        {
           
            //disable moving animation
        }
        public override void OnStateUpdate()
        {
            //do something 
        }
    }
}