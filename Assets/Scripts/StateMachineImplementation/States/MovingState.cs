using UnityEngine;

namespace PlayerStates
{
    public class MovingState: PlayerState
    {
          public MovingState()
        {
            OnStateEnter();

        }
        public override void OnStateEnter()
        {
            Debug.Log("Inside moving state of player");
            //play moving animation
        }
        public override void OnStateExit()
        {
            Debug.Log("Exitting moving state of player");
            //disable moving animation
        }
        public override void OnStateUpdate()
        {
            //do something 
        }
    }
}