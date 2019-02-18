using UnityEngine.SceneManagement;
using StateMachineImplementation;
using StateMachine;
using GameplayInterfaces;
using Lobby;
using System;

namespace Common
{
    public class SceneLoader : ISceneLoader
    {
        public SceneLoader()
        {

        }
        private void Start()
        {
            StateMachineService.Instance.SetCurrentStateMachineType(StateMachineEnumTypes.LOADING);
            RegisterEvents();
        }

        private void RegisterEvents()
        {

        }

        public void OnClickPlay(string _gameScene = null)
        {
            LobbyService.Instance.UnSubscribeDummyControllers();
            SceneManager.LoadScene(_gameScene == null ? "Game" : _gameScene);
            StateMachineService.Instance.SetCurrentStateMachineType(StateMachineEnumTypes.GAME);
            StateMachineService.Instance.InvokeOnEnterGameScene();

        }
        public void OnClickStart(string _startScene = null)
        {
            SceneManager.LoadScene(_startScene == null ? "Start" : _startScene);
            StateMachineService.Instance.SetCurrentStateMachineType(StateMachineEnumTypes.START);
            StateMachineService.Instance.InvokeOnEnterStartScene();
        }
        public void OnGameOver()
        {
            SceneManager.LoadScene("GameOver");
            StateMachineService.Instance.SetCurrentStateMachineType(StateMachineEnumTypes.GAMEOVER);
            StateMachineService.Instance.InvokeOnEnterGameOverScene();
        }
        public void OnReturnHome()
        {
            SceneManager.LoadScene(0);
            StateMachineService.Instance.SetCurrentStateMachineType(StateMachineEnumTypes.LOADING);
            StateMachineService.Instance.InvokeOnLoadingScene();
        }
        public void OnReplay()
        {
            StateMachineService.Instance.SetCurrentStateMachineType(StateMachineEnumTypes.REPLAY);
            StateMachineService.Instance.InvokeOnStartReplay();
        }


    }
}