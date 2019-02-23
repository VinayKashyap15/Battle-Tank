using StateMachineImplementation;

namespace StateMachine
{
    public class GameStateMachine : StateMachineBase
    {      
        public GameStateMachine(StateMachineEnumTypes _type)
        {
            currentStateMachine=_type;           
        }

    }
}