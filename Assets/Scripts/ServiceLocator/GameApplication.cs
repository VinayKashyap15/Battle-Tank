using Common;
using UnityEngine;
using ReplaySystem;
using Lobby;
using InputComponents;
using Player;
using Enemy;
using StateMachineImplementation;
using System.Collections.Generic;
using GameplayInterfaces;
namespace ServiceLocator
{
    public class GameApplication : SingletonBase<GameApplication>
    {
        [SerializeField]
        private InputScriptableObjectList listOfPlayerInputComponents;

        [SerializeField]
        private PlayerPrefabScriptableObject newPlayerPrefabScriptableObj;

        [SerializeField]
        private Camera miniMapCameraPrefab;

        private List<IService> listOfServices = new List<IService>();
        protected override void OnInitialize()
        {
            base.OnInitialize();
            Register<ISceneLoader>(new SceneLoader());
            Register<IReplayService>(new ReplayService());
            Register<ILobbyService>(new LobbyService());
            Register<IStateMachineService>(new StateMachineService());
            Register<IPlayerService>(new PlayerService(listOfPlayerInputComponents,newPlayerPrefabScriptableObj,miniMapCameraPrefab));



        }

        public void Register<T>(T _service) where T : IService
        {
            listOfServices.Add(_service);
            Debug.Log(" Register Service:" + _service.ToString());
        }

        public void DeRegister<T>(T _service) where T : IService
        {
            listOfServices.Remove(_service);
        }

        public T GetService<T>() where T : IService
        {
            foreach (IService item in listOfServices)
            {
                if (item is T)
                {
                    return (T)item;
                }
            }
            return default(T);
        }
    }
}