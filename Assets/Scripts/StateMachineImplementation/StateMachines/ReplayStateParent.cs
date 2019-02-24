using StateMachineImplementation;
using PlayerStates;

namespace StateMachine
{
    public class ReplayStateParent : StateMachineBase
    {      

       public ReplayStateParent(StateMachineEnumTypes _type)
        {
            currentStateMachine=_type;
        }
    }
}