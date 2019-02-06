using UnityEngine;
namespace PlayerStates
{
    public class FiringState : PlayerState
    {

        public FiringState()
        {
            OnStateEnter();
        }
        public override void OnStateEnter()
        {
            Debug.Log("Inside firing state of player");
            //play firing animation
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