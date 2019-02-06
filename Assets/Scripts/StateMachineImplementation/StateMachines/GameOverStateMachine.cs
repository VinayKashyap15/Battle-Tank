using StateMachineImplementation;
using PlayerStates;

namespace StateMachine
{
    public class GameOverStateMachine : StateMachineBase
    {      

       public GameOverStateMachine(StateMachineEnumTypes _type)
        {
            currentStateMachine=_type;
        }
    }
}