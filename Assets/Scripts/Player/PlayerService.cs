using UnityEngine;
using ServiceLocator;
using ReplaySystem;
using InputComponents;
using CameraManagement;
using Common;
using System.Collections.Generic;
using System.Linq;
using SceneSpecific;
using RewardSystem;
using GameplayInterfaces;
using Player.UI;
using SaveFile;
using AchievementSystem;
using System;

namespace Player
{
    public class PlayerService : IPlayerService
    {

        private InputScriptableObjectList listOfPlayerInputComponents;

        private PlayerPrefabScriptableObject newPlayerPrefabScriptableObj;

        private Camera miniMapCameraPrefab;

        private PlayerController playerControllerInstance;
        private GameObject playerPrefab;
        private GameObject playerInstance;
        private int playerID = 0;
        private int dieActionCalled = 0;

        public PlayerService(InputScriptableObjectList _listOfPlayerInputComponents, PlayerPrefabScriptableObject _playerPrefab, Camera _minimapCam=null)
        {
            listOfPlayerInputComponents=_listOfPlayerInputComponents;
            newPlayerPrefabScriptableObj=_playerPrefab;
            miniMapCameraPrefab=_minimapCam;

            if (listOfPlayerInputComponents)
            {
                noOfPlayers = listOfPlayerInputComponents.playerList.Count;
            }
            else
            {
                noOfPlayers = 1;
            }
        }
        public void SetConfig(RewardProperties _rewardProperty)
        {

        }

        private SceneController currentSceneController;

        public List<PlayerController> listOfPlayerControllers = new List<PlayerController>();
        //player id and kill count
        private Dictionary<int, int> enemyKillCountData = new Dictionary<int, int>();
        //player id and games played
        private Dictionary<int, int> playerGamesPlayedData = new Dictionary<int, int>();

        private List<Camera> playerMainCamera = new List<Camera>();

        public event Action RegenerateHealth;
        public event Action<int, int> PlayerDeath;
        public event Action<int, int> HighScoreUpdate;
        public event Action<int, int> EnemyKill;

        public event Action UpdatePlayer;
        private int noOfPlayers;

        private Material _rewardedMat;


        private GameObject SpawnPrefabInstance(Vector3 _spawnPos)
        {
            if (!playerPrefab)
            {
                playerPrefab = Resources.Load("Player") as GameObject;
            }
            GameObject _playerInstance;
            _playerInstance = GameObject.Instantiate(playerPrefab);
            _playerInstance.transform.position = _spawnPos;
            return _playerInstance;
        }
       
        public void OnStart(SceneController _currentSceneController)
        {
            listOfPlayerControllers.Clear();
            if (newPlayerPrefabScriptableObj)
            {
                playerPrefab = newPlayerPrefabScriptableObj.newPlayerPrefab;
            }
            if (_currentSceneController != null)
            {
                currentSceneController = _currentSceneController;
            }
            ScoreManager.Instance.SetSceneController(currentSceneController);
            SpawnPlayers();
            Enemy.EnemyService.Instance.EnemyDeath += InvokePlayerScore;
        }
        public void SetSpawnPos(Vector3 position)
        {
            SpawnPlayers();
        }

        public void SaveMaterialFromReward(Material materialToSave)
        {
            _rewardedMat = materialToSave;

        }
        public void OnUpdate()
        {
            UpdatePlayer?.Invoke();
        }
        public void SpawnPlayers()
        {

            enemyKillCountData.Clear();
            playerGamesPlayedData.Clear();
            playerID = 0;
            PlayerController _playerControllerInstance;
            if (listOfPlayerInputComponents)
            {
                Vector3 pos = new Vector3(0, 0, 0);


                for (int i = 0; i < listOfPlayerInputComponents.playerList.Count; i++)
                {
                    playerInstance = SpawnPrefabInstance(pos);

                    _playerControllerInstance = new PlayerController(playerInstance.GetComponent<PlayerView>(), playerID, listOfPlayerInputComponents.playerList.ElementAt(i), _rewardedMat);
                    listOfPlayerControllers.Add(_playerControllerInstance);
                    if (!GameApplication.Instance.GetService<IReplayService>().GetReplayValue())
                    {
                        enemyKillCountData.Add(_playerControllerInstance.GetID(), PlayerSaveData.Instance.GetEnemyKillData(_playerControllerInstance.GetID()));
                        playerGamesPlayedData.Add(_playerControllerInstance.GetID(), PlayerSaveData.Instance.GetGamesPlayedData(_playerControllerInstance.GetID()));
                        ScoreManager.Instance.AddPlayerUI(_playerControllerInstance);
                    }
                    SetGameJoined(_playerControllerInstance.GetID());

                    SetupCameras(_playerControllerInstance, playerID);

                    pos += new Vector3(3, 0, 0);
                    playerID += 1;



                }
            }
            else
            {
                Vector3 pos = new Vector3(0, 0, 0);
                playerInstance = SpawnPrefabInstance(pos);
                _playerControllerInstance = new PlayerController(playerInstance.GetComponent<PlayerView>(), playerID, null, _rewardedMat);
                listOfPlayerControllers.Add(_playerControllerInstance);
                enemyKillCountData.Add(_playerControllerInstance.GetID(), 0);
                ScoreManager.Instance.AddPlayerUI(_playerControllerInstance);
                SetupCameras(_playerControllerInstance, playerID);
            }



        }

        private void SetupCameras(PlayerController _controller, int _id)
        {
            GameObject miniMapInstance = GameObject.Instantiate(miniMapCameraPrefab.gameObject) as GameObject;

            var mcam = miniMapInstance.GetComponent<MiniMapSetup>();
            Transform t = _controller.GetFollowTarget();
            mcam.SetupTarget(t);
            miniMapInstance.GetComponent<MiniMapSetup>().SetRenderTexture(_id);
            Camera _mainCamera = _controller.GetMainCamera();
            playerMainCamera.Add(_mainCamera);

            playerMainCamera[_id].rect = new Rect((1f / noOfPlayers) * _controller.GetID(), 0, 1f / noOfPlayers, 1);
        }

        private void SetGameJoined(int _id)
        {
            int currentGamesValue;
            playerGamesPlayedData.TryGetValue(_id, out currentGamesValue);
            Debug.Log("player" + _id.ToString() + " value " + currentGamesValue.ToString());
            PlayerSaveData.Instance.SetGamesPlayedData(_id, currentGamesValue + 1);
            playerGamesPlayedData[_id] = currentGamesValue + 1;

        }
        public void DestroyPlayer(PlayerController _playerController)
        {

            RemoveFromList(_playerController);
            _playerController.DestroySelf();

            _playerController = null;

            if (listOfPlayerControllers.Count == 0)
            {
                playerMainCamera.Clear();
                GameApplication.Instance.GetService<ISceneLoader>().OnReplay();
            }
        }
        private void RemoveFromList(PlayerController _playerController)
        {
            if (listOfPlayerControllers.Contains(_playerController))
            {
                listOfPlayerControllers.Remove(_playerController);
                playerMainCamera.Remove(_playerController.GetMainCamera());
            }
            else
            {
                Debug.Log("player doesn't exist in list");
                return;
            }

        }
        public void SetCurrentInstance(PlayerController _playerControllerInstance)
        {
            playerControllerInstance = _playerControllerInstance;

        }
        public void UpdateScoreView(PlayerController _p, int _score, int _playerID)
        {
            ScoreManager.Instance.UpdateScoreView(_p, _score, _playerID);
        }
        public Vector3 GetRespawnSafePosition()
        {
            Vector3 pos = currentSceneController.FindSafePosition();

            return pos;
        }
        public void InvokePlayerDeath(int _id, int _dieActionCalled)
        {
            PlayerDeath?.Invoke(_id, _dieActionCalled);
        }
        public void InvokePlayerScore(int _enemyID, Enemy.EnemyType _type, int playerID)
        {
            int enemyKill = GetEnemyKillFromID(playerID);
            playerControllerInstance.UpdateScore(_enemyID, _type);
            EnemyKill?.Invoke(playerControllerInstance.GetID(), enemyKill);
        }
        private int GetEnemyKillFromID(int playerID)
        {
            int killCount;
            enemyKillCountData.TryGetValue(playerID, out killCount);
            return killCount;
        }
        public void InvokeHighScoreAchievement(int _id, int _highScore)
        {
            HighScoreUpdate?.Invoke(_id, _highScore);
        }
        public void AddKillCount(int _playerID)
        {
            int currentKillCount;
            if (!enemyKillCountData.ContainsKey(_playerID))
            {
                return;
            }
            enemyKillCountData.TryGetValue(_playerID, out currentKillCount);
            //enemyKillCountData.Add(_playerID,currentKillCount++);
            enemyKillCountData[_playerID] = currentKillCount + 1;

        }
        public int GetNoOfPlayers()
        {
            return noOfPlayers;
        }

        public List<PlayerController> GetListOfPlayerControllers()
        {
            return listOfPlayerControllers;
        }
    }
}
