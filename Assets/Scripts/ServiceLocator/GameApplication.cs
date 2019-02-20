using Common;
using Enemy;
using GameplayInterfaces;
using InputComponents;
using Lobby;
using Player;
using Player.UI;
using ReplaySystem;
using RewardSystem;
using Sound;
using StateMachineImplementation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Weapons.Bullet;

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
        [SerializeField]
        private RewardScriptableObject rewardObjList;
        [SerializeField]
        private List<SoundController> listOfAudioSources = new List<SoundController>();
        [SerializeField]
        private SoundScriptableObject soundScriptableObject;
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
            Register<IPlayerService>(new PlayerService(listOfPlayerInputComponents, newPlayerPrefabScriptableObj, miniMapCameraPrefab));
            Register<IEnemyService>(new EnemyService(listOfEnemies));
            Register<IRewardService>(new RewardService(rewardObjList));
            Register<IScoreManager>(new ScoreManager());
            Register<IBulletService>(new BulletService(typeOfBullet));

        }

        private void Start()
        {
            foreach (SoundController _sound in listOfAudioSources)
            {
                DontDestroyOnLoad(_sound.gameObject);
            }

            Register<ISoundService>(new SoundService(soundScriptableObject, listOfAudioSources));



        }


        public void Register<T>(T _service) where T : IService
        {
            listOfServices.Add(_service);
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