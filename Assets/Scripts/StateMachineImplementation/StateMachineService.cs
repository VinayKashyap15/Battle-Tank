using System;
using Common;
using UnityEngine;
using GameplayInterfaces;
using StateMachine;

namespace StateMachineImplementation
{
    public class StateMachineService : IStateMachineService
    {
        public event Action OnEnterStartScene;
        public event Action OnEnterGameScene;
        public event Action OnEnterGameOverScene;
        public event Action OnEnterLoadingScene;
        public event Action OnStartReplay;
        public event Action OnPause;
        public event Action OnResume;

        private bool isPaused = false;
        private StateMachineEnumTypes currentStateMachineType;
        private StateMachineEnumTypes previousStateMachineType;
        private StateMachineBase currentStateMachine;



        private void InvokeResumeActions()
        {
            OnResume?.Invoke();
            SetCurrentStateMachineType(previousStateMachineType);

        }

        private void InvokePauseActions()
        {
            OnPause?.Invoke();
            SetPreviousStateMachineType(currentStateMachineType);
        }
        private void CreateStateMachine()
        {
            switch (currentStateMachineType)
            {
                case StateMachineEnumTypes.START:
                    currentStateMachine = new StartStateMachine(currentStateMachineType);
                    break;
                case StateMachineEnumTypes.GAME:
                    currentStateMachine = new GameStateMachine(currentStateMachineType);
                    break;
                case StateMachineEnumTypes.GAMEOVER:
                    currentStateMachine = new GameOverStateMachine(currentStateMachineType);
                    break;
                case StateMachineEnumTypes.LOADING:
                    currentStateMachine = new LoadingStateMachine(currentStateMachineType);
                    break;
                case StateMachineEnumTypes.REPLAY:
                    currentStateMachine = new ReplayStateParent(currentStateMachineType);
                    break;

            }

        }
        public void SetGamePause()
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                InvokePauseActions();
            }
            else
            {
                InvokeResumeActions();
            }
        }

        public void InvokeOnEnterStartScene()
        {
            OnEnterStartScene?.Invoke();

        }
        public void InvokeOnEnterGameScene()
        {
            OnEnterGameScene?.Invoke();
        }
        public void InvokeOnEnterGameOverScene()
        {
            OnEnterGameOverScene?.Invoke();
        }
        public void InvokeOnLoadingScene()
        {
            OnEnterLoadingScene?.Invoke();
        }
        public void SetCurrentStateMachineType(StateMachineEnumTypes _currentStateMachine)
        {
            currentStateMachineType = _currentStateMachine;

            CreateStateMachine();
        }
        public void SetPreviousStateMachineType(StateMachineEnumTypes _currentStateMachine)
        {
            previousStateMachineType = _currentStateMachine;
        }

        public void InvokeOnStartReplay()
        {
            OnStartReplay?.Invoke();
        }


        public StateMachineEnumTypes GetCurrentStateMachineType()
        {
            return currentStateMachineType;
        }
    }
}