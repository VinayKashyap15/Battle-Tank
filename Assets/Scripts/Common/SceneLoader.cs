using UnityEngine.SceneManagement;
using ServiceLocator;
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
            GameApplication.Instance.GetService<IStateMachineService>().SetCurrentStateMachineType(StateMachineEnumTypes.LOADING);
            RegisterEvents();
        }

        private void RegisterEvents()
        {

        }

        public void OnClickPlay(string _gameScene = null)
        {
            GameApplication.Instance.GetService<ILobbyService>().UnSubscribeDummyControllers();
            SceneManager.LoadScene(_gameScene == null ? "Game" : _gameScene);
            GameApplication.Instance.GetService<IStateMachineService>().SetCurrentStateMachineType(StateMachineEnumTypes.GAME);
            GameApplication.Instance.GetService<IStateMachineService>().InvokeOnEnterGameScene();

        }
        public void OnClickStart(string _startScene = null)
        {
            SceneManager.LoadScene(_startScene == null ? "Start" : _startScene);
            GameApplication.Instance.GetService<IStateMachineService>().SetCurrentStateMachineType(StateMachineEnumTypes.START);
            GameApplication.Instance.GetService<IStateMachineService>().InvokeOnEnterStartScene();
        }
        public void OnGameOver()
        {
            SceneManager.LoadScene("GameOver");
            GameApplication.Instance.GetService<IStateMachineService>().SetCurrentStateMachineType(StateMachineEnumTypes.GAMEOVER);
            GameApplication.Instance.GetService<IStateMachineService>().InvokeOnEnterGameOverScene();
        }
        public void OnReturnHome()
        {
            SceneManager.LoadScene(0);
            GameApplication.Instance.GetService<IStateMachineService>().SetCurrentStateMachineType(StateMachineEnumTypes.LOADING);
            GameApplication.Instance.GetService<IStateMachineService>().InvokeOnLoadingScene();
        }
        public void OnReplay()
        {
            GameApplication.Instance.GetService<IStateMachineService>().SetCurrentStateMachineType(StateMachineEnumTypes.REPLAY);
            GameApplication.Instance.GetService<IStateMachineService>().InvokeOnStartReplay();
        }


    }
}