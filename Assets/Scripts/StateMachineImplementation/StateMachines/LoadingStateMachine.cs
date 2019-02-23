using StateMachineImplementation;
using PlayerStates;

namespace StateMachine
{
    public class LoadingStateMachine : StateMachineBase
    {
        
        public LoadingStateMachine(StateMachineEnumTypes _type)
        {
            currentStateMachine=_type;
        }

      
    }
}