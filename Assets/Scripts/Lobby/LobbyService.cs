using System.Collections.Generic;
using Common;
using UnityEngine;
using GameplayInterfaces;
using RewardSystem;
using SceneSpecific;
using Player;
using System;

namespace Lobby
{
    public class LobbyService :SingletonBase<LobbyService>
    {
        int noOfPlayers;
        List<PlayerController> dummyControllerList= new List<PlayerController>();

        PlayerController dummyController;
        PlayerView _dummyView;
        int id;
        GameObject prefab;

            LobbySceneController sceneController;
        public void OnStart()
        {
            noOfPlayers=PlayerService.Instance.GetNoOfPlayers();
           prefab=Resources.Load("Player") as GameObject;
            
            for(int i=0;i<noOfPlayers;i++)
            {
                SpawnDummyController(id);
            }
        }

       
        public void SavePlayerConfig(RewardProperties _currentProperty)
        {
            dummyController.SetMaterial(_currentProperty.GetMaterialFromData());
            SaveMaterial(_currentProperty.GetMaterialFromData());
        }

        public void SaveMaterial(Material _materialToSave)
        {
            PlayerService.Instance.SaveMaterialFromReward(_materialToSave);
        }

        public void OnButtonClicked(RewardProperties rewardProperties)
        {
            sceneController.OnClickReward(rewardProperties);
        }

        public void SetSceneController(LobbySceneController _controller)
        {   
            sceneController=_controller;
        }

        private void SpawnDummyController(int id)
        {
             
            GameObject inst=GameObject.Instantiate(prefab,Vector3.zero,Quaternion.identity);
             _dummyView=inst.GetComponent<PlayerView>();
            dummyController=new PlayerController(_dummyView,id);
            dummyControllerList.Add(dummyController);

        }

        public void UnSubscribeDummyControllers()
        {
            foreach (PlayerController dummyControllerInst in dummyControllerList)
            {
                dummyControllerInst.DestroySelf();    
            }
            dummyControllerList.Clear();
        }

    
    }
}