using Common;
using UnityEngine;
using ReplaySystem;
using Lobby;
using InputComponents;
using Weapons.Bullet;
using Player;
using Enemy;
using StateMachineImplementation;
using System.Collections.Generic;
using System.Linq;
using GameplayInterfaces;
namespace ServiceLocator
{
    public class GameApplication : SingletonBase<GameApplication>
    {
        [SerializeField]
        private InputScriptableObjectList listOfPlayerInputComponents;
        [SerializeField]
        private EnemyScriptableObjectList listOfEnemies;

        [SerializeField]
        private PlayerPrefabScriptableObject newPlayerPrefabScriptableObj;

        [SerializeField]
        private Camera miniMapCameraPrefab;

        [SerializeField]
        private BULLET_TYPE typeOfBullet;
        private List<IService> listOfServices = new List<IService>();
       
       private int startTime;
        protected override void OnInitialize()
        {
            base.OnInitialize();
            Register<ISceneLoader>(new SceneLoader());
            Register<IStateMachineService>(new StateMachineService());
            Register<IReplayService>(new ReplayService());
            Register<ILobbyService>(new LobbyService());
            Register<IInputManagerService>(new InputManagerBase());
            Register<IPlayerService>(new PlayerService(listOfPlayerInputComponents,newPlayerPrefabScriptableObj,miniMapCameraPrefab));
            Register<IEnemyService>(new EnemyService(listOfEnemies));
            Register<IBulletService>(new BulletService(typeOfBullet));

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