using UnityEngine;

namespace PlayerStates
{
    public class IdleState : PlayerState
    {
        public IdleState()
        {
            OnStateEnter();
        }
        public override void OnStateEnter()
        {
            Debug.Log("Inside on State Enter of Idle State");
            //play idle animation
        }
        public override void OnStateExit()
        {
            Debug.Log("Exitting idle state of player");
            //disable idle animation
        }
        public override void OnStateUpdate()
        {
            //do something 
        }
    }
}