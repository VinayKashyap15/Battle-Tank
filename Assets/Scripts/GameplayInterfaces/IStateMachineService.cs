using StateMachine;
using System;

namespace GameplayInterfaces
{
    public interface IStateMachineService : IService
    {
        event Action OnEnterStartScene;
        event Action OnEnterGameScene;
        event Action OnEnterGameOverScene;
        event Action OnEnterLoadingScene;
        event Action OnStartReplay;
        event Action OnPause;
        event Action OnResume;

        void SetGamePause();
        void InvokeOnEnterStartScene();
        void InvokeOnEnterGameScene();
        void InvokeOnEnterGameOverScene();
        void InvokeOnLoadingScene();
        void SetCurrentStateMachineType(StateMachineEnumTypes _currentStateMachine);
        void SetPreviousStateMachineType(StateMachineEnumTypes _currentStateMachine);
        void InvokeOnStartReplay();
        StateMachineEnumTypes GetCurrentStateMachineType();
    }
}