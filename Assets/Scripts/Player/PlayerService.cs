using UnityEngine;
using InputComponents;
using Common;
using System.Collections.Generic;
using System.Linq;
using Player.UI;

namespace Player
{
    public class PlayerService : SingletonBase<PlayerService>
    {

        
        public List<PlayerController> listOfPlayerControllers = new List<PlayerController>();
        [SerializeField]
        private InputScriptableObjectList listOfPlayerInputComponents;
        [SerializeField]
        private PlayerPrefabScriptableObject newPlayerPrefabScriptableObj;
        private PlayerController playerControllerInstance;
        private GameObject playerPrefab;

      

        private GameObject playerInstance;
        int playerID = 0;

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

        public void OnStart()
        {
            if(newPlayerPrefabScriptableObj)
            {
                playerPrefab=newPlayerPrefabScriptableObj.newPlayerPrefab;
            }
            SpawnPlayers();
        }

        private void SpawnPlayers()
        {
            PlayerController _playerControllerInstance;
            if (listOfPlayerInputComponents)
            {
                Vector3 pos = new Vector3(0, 0, 0);
               
                
                for (int i = 0; i < listOfPlayerInputComponents.playerList.Count; i++)
                {
                    playerInstance=SpawnPrefabInstance(pos);                    
                    _playerControllerInstance = new PlayerController(playerInstance.GetComponent<PlayerView>(), playerID,listOfPlayerInputComponents.playerList.ElementAt(i));                    
                    listOfPlayerControllers.Add(_playerControllerInstance);
                    ScoreManager.Instance.AddPlayerUI(_playerControllerInstance);    
                    pos += new Vector3(3, 0, 0);                  
                    playerID += 1;
                }
            }
            else
            {
                playerInstance=SpawnPrefabInstance(new Vector3(0, 0, 0));
                _playerControllerInstance = new PlayerController(playerInstance.GetComponent<PlayerView>(),playerID,null);               
                listOfPlayerControllers.Add(_playerControllerInstance);
                ScoreManager.Instance.AddPlayerUI(_playerControllerInstance);
            }
         
        }

        public void DestroyPlayer(PlayerController _playerController)
        {
            RemmoveFromList(_playerController);
            _playerController.DestroySelf();
            _playerController = null;
        }

        public void RemmoveFromList(PlayerController _playerController)
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

            if(listOfPlayerControllers.Count==0)
            {
                SceneLoader.Instance.OnGameOver();
            }
        }

        public PlayerController GetPlayerControllerInstance()
        {
            return playerControllerInstance;
        }
        public void SetCurrentInstance(PlayerController _playerControllerInstance)
        {
            playerControllerInstance = _playerControllerInstance;
        }

        public void UpdateScoreView(PlayerController _p,int _score)
        {
            ScoreManager.Instance.UpdateScoreView(_p,_score);
        }
    }
}
