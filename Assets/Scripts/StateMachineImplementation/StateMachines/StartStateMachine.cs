using StateMachineImplementation;
using PlayerStates;

namespace StateMachine
{
    public class StartStateMachine : StateMachineBase
    {      
        public StartStateMachine(StateMachineEnumTypes _type)
        {
            currentStateMachine=_type;
        }


    }
}