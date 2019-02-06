using System;
using Common;
using UnityEngine;
using StateMachine;

namespace StateMachineImplementation
{
    public class StateMachineService : SingletonBase<StateMachineService>
    {
        public event Action OnEnterStartScene;
        public event Action OnEnterGameScene;
        public event Action OnEnterGameOverScene;
        public event Action OnEnterLoadingScene;

        private StateMachineEnumTypes currentStateMachineType;
        private StateMachineBase currentStateMachine;
        private void Start()
        {
           // OnEnterLoadingScene?.Invoke();
            //SetCurrentStateMachineType(StateMachineEnumTypes.LOADING);            
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
            OnEnterGameScene?.Invoke();
        }
        public void InvokeOnLoadingScene()
        {
            OnEnterGameScene?.Invoke();
        }
        public void SetCurrentStateMachineType(StateMachineEnumTypes _currentStateMachine)
        {
            currentStateMachineType = _currentStateMachine;
            Debug.Log("Current State Machine : "+currentStateMachineType.ToString());
            CreateStateMachine();
        }

        private void CreateStateMachine()
        {
            switch(currentStateMachineType){
                case StateMachineEnumTypes.START:
                    currentStateMachine= new StartStateMachine(currentStateMachineType);
                break;
                case StateMachineEnumTypes.GAME:
                    currentStateMachine= new GameStateMachine(currentStateMachineType);
                break;
                case StateMachineEnumTypes.GAMEOVER :
                    currentStateMachine= new GameOverStateMachine(currentStateMachineType);
                break;
                case StateMachineEnumTypes.LOADING:
                    currentStateMachine= new LoadingStateMachine(currentStateMachineType);
                break;
            }            
            
        }
    }
}