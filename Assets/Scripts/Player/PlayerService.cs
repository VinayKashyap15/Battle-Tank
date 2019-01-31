using UnityEngine;
using InputComponents;
using Common;
using System;

namespace Player
{
    public class PlayerService : SingletonBase<PlayerService>
    {

        private PlayerController playerController;
        [SerializeField]
        private InputScriptabelObject customInputScheme;
        private GameObject playerPrefab;
        private GameObject playerInstance;
        

        protected override void OnInitialize()
        {
            base.OnInitialize();
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            if(!playerPrefab)
            {
                playerPrefab = Resources.Load("Player") as GameObject;
            }
            playerInstance = GameObject.Instantiate(playerPrefab);

            playerController = new PlayerController(playerInstance.GetComponent<PlayerView>());

            if (customInputScheme)
            {
                playerController = new PlayerController(playerInstance.GetComponent<PlayerView>(), customInputScheme);
            }
        }

        private void Start()
        {
            InputManagerBase.Instance.PopulatePlayerList(playerController);
        }

        public PlayerController GetCurrentPlayerController()
        {
            return playerController;
        }
       
    }
}
