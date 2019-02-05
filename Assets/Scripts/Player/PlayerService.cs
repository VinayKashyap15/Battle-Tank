using UnityEngine;
using InputComponents;
using Common;
using System.Collections.Generic;
using System.Linq;
using SceneSpecific;
using Player.UI;
using SaveFile;
using SaveFile.AchievementSystem;
using System;

namespace Player
{
    public class PlayerService : SingletonBase<PlayerService>
    {
        [SerializeField]
        private InputScriptableObjectList listOfPlayerInputComponents;
        [SerializeField]
        private PlayerPrefabScriptableObject newPlayerPrefabScriptableObj;

        

        private PlayerController playerControllerInstance;
        private GameObject playerPrefab;
        private GameObject playerInstance;
        private int playerID = 0;
        private int dieActionCalled = 0;        
        private SceneController currentSceneController;

        public List<PlayerController> listOfPlayerControllers = new List<PlayerController>();
        private Dictionary<int, int> enemyKillCountData = new Dictionary<int, int>();
        private Dictionary<int, int> playerGamesPlayedData = new Dictionary<int, int>();

        public event Action RegenrateHealth;
        public event Action<int, int> PlayerDeath;
        public event Action<int,int> HighScoreUpdate;
        public event Action<int, int> EnemyKill;
        public event Action<int, int> GamesJoined;

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

            if (newPlayerPrefabScriptableObj)
            {
                playerPrefab = newPlayerPrefabScriptableObj.newPlayerPrefab;
            }
            currentSceneController = _currentSceneController;
            RegisterServices();
            SpawnPlayers();
           
        }
        private void RegisterServices()
        {
            PlayerDeath += PlayerSaveData.Instance.SetDieMark;
            PlayerDeath += AchievementManager.Instance.DieAchievements;
            HighScoreUpdate += AchievementManager.Instance.HighScoreAchievements;
            EnemyKill += AchievementManager.Instance.EnemyKillAchievements;
            GamesJoined += AchievementManager.Instance.GamePlayedAchievements;
        }
        private void SpawnPlayers()
        {
            PlayerController _playerControllerInstance;
            if (listOfPlayerInputComponents)
            {
                Vector3 pos = new Vector3(0, 0, 0);


                for (int i = 0; i < listOfPlayerInputComponents.playerList.Count; i++)
                {
                    playerInstance = SpawnPrefabInstance(pos);
                    _playerControllerInstance = new PlayerController(playerInstance.GetComponent<PlayerView>(), playerID, listOfPlayerInputComponents.playerList.ElementAt(i));
                    listOfPlayerControllers.Add(_playerControllerInstance);                    
                    enemyKillCountData.Add(_playerControllerInstance.GetID(),PlayerSaveData.Instance.GetEnemyKillData(_playerControllerInstance.GetID()));
                    playerGamesPlayedData.Add(_playerControllerInstance.GetID(),PlayerSaveData.Instance.GetGamesPlayedData(_playerControllerInstance.GetID()));

                    SetGameJoined(_playerControllerInstance.GetID());

                    ScoreManager.Instance.AddPlayerUI(_playerControllerInstance);
                    pos += new Vector3(3, 0, 0);
                    playerID += 1;

                }
            }
            else
            {
                playerInstance = SpawnPrefabInstance(new Vector3(0, 0, 0));
                _playerControllerInstance = new PlayerController(playerInstance.GetComponent<PlayerView>(), playerID, null);
                listOfPlayerControllers.Add(_playerControllerInstance);
                enemyKillCountData.Add(_playerControllerInstance.GetID(), 0);
                ScoreManager.Instance.AddPlayerUI(_playerControllerInstance);
            }



        }

        private void SetGameJoined(int _id)
        {
            int currentGamesValue;
            playerGamesPlayedData.TryGetValue(_id,out currentGamesValue);
            Debug.Log("player"+_id.ToString()+" value " +currentGamesValue.ToString());
            PlayerSaveData.Instance.SetGamesPlayedData(_id,currentGamesValue+1);
            playerGamesPlayedData[_id] = currentGamesValue + 1;
            GamesJoined.Invoke(_id,currentGamesValue+1);
        }

        public void DestroyPlayer(PlayerController _playerController)
        {

            RemoveFromList(_playerController);
            _playerController.DestroySelf();
            _playerController = null;
        }
        public void RemoveFromList(PlayerController _playerController)
        {
            if (listOfPlayerControllers.Contains(_playerController))
            {
                listOfPlayerControllers.Remove(_playerController);
            }
            else
            {
                Debug.Log("player doesn't exist in list");
                return;
            }

            if (listOfPlayerControllers.Count == 0)
            {
                SceneLoader.Instance.OnGameOver();
            }
        }       
        public void SetCurrentInstance(PlayerController _playerControllerInstance)
        {
            playerControllerInstance = _playerControllerInstance;
            RegenrateHealth += playerControllerInstance.RegenerateHealth;
        }
        public void UpdateScoreView(PlayerController _p, int _score, int _playerID)
        {
            ScoreManager.Instance.UpdateScoreView(_p, _score, _playerID);
        }
        public Vector3 Respawn()
        {

            Vector3 pos = currentSceneController.FindSafePosition();
            // RegenrateHealth.Invoke();
            return pos;
        }
        public void InvokePlayerDeath(int _id)
        {
            dieActionCalled++;
            PlayerDeath.Invoke(_id, dieActionCalled);
        }
        public void InvokePlayerScore(int _enemyID, Enemy.EnemyType _type,int playerID)
        {
            int enemyKill = GetEnemyKillFromID(playerID);
            playerControllerInstance.UpdateScore(_enemyID, _type);
            EnemyKill.Invoke(playerControllerInstance.GetID(),enemyKill);
        }

        private int GetEnemyKillFromID(int playerID)
        {
            int killCount;
            enemyKillCountData.TryGetValue(playerID, out killCount);
            return killCount;
        }

        public void InvokeHighScoreAchievement(int _id,int _highScore)
        {
            HighScoreUpdate.Invoke(_id,_highScore);
        }

        public void AddKillCount(int _playerID)
        {
            int currentKillCount;
            if(!enemyKillCountData.ContainsKey(_playerID))
            {
                return;
            }
            enemyKillCountData.TryGetValue(_playerID, out currentKillCount);
            //enemyKillCountData.Add(_playerID,currentKillCount++);
            enemyKillCountData[_playerID] = currentKillCount+1;
            
        }
    }
}
