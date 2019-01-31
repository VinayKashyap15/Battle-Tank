using UnityEngine;
using UnityEngine.UI;
using InputComponents;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Player
{
    public class PlayerService : SingletonBase<PlayerService>
    {

        
        public List<PlayerController> listOfPlayerControllers = new List<PlayerController>();
        [SerializeField]
        private InputScriptableObjectList listOfInputs;
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

        private void Start()
        {
            SpawnPlayers();
        }

        private void SpawnPlayers()
        {
            PlayerController _playerControllerInstance;
            if (listOfInputs)
            {
                Vector3 pos = new Vector3(0, 0, 0);
               
                
                for (int i = 0; i < listOfInputs.inputList.Count; i++)
                {
                    playerInstance=SpawnPrefabInstance(pos);
                    
                    _playerControllerInstance = new PlayerController(playerInstance.GetComponent<PlayerView>(), listOfInputs.inputList.ElementAt(i),playerID);                    
                    listOfPlayerControllers.Add(_playerControllerInstance);
                    pos += new Vector3(3, 0, 0);
                  
                    playerID += 1;
                }
            }
            else
            {
                playerInstance=SpawnPrefabInstance(new Vector3(0, 0, 0));
                _playerControllerInstance = new PlayerController(playerInstance.GetComponent<PlayerView>(),playerID);
            }
         
        }  

    }
}
